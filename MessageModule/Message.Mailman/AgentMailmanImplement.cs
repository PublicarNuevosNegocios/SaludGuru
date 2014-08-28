﻿using Message.DAL.MySqlDao;
using System.Configuration;
using Message.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carvajal.Mail;
using System.Messaging;
using System.Threading.Tasks;
using MessageMailman = Carvajal.Mail.Message;
using MessageModule.Controller;
using Message.Interfaces;
using System.IO;

namespace Message.Mailman
{
    public class AgentMailmanImplement : IAgent
    {
        #region Funciones y variables privadas

        /// <summary>
        /// Variable para el acceso a funciones DAL
        /// </summary>
        private MessageDataController _controller = new MessageDataController();

        /// <summary>
        /// Función  que contiene la lógica para el envío del mensaje.
        /// </summary>
        /// <param name="MessageToSend">Mensaje que se va a enviar</param>
        /// <returns>Información del mensaje enviado </returns>
        public MessageModel SendMessage(AgentModel MessageToSend)
        {
            #region Variables
            MessageModel modelToreturn = new MessageModel();
            #endregion
            
            foreach (AddressModel item in MessageToSend.AddressToSend)
            {
                MessageQueue messageQueue = new MessageQueue();
                messageQueue.Path = MessageToSend.MessageConfig["MailmanPath"];
                messageQueue.Formatter = new XmlMessageFormatter(new[] { typeof(MessageMailman) });
                MessageMailman mailMessage = new MessageMailman();
                try
                {
                    mailMessage.From = new Address(MessageToSend.MessageConfig["From"]);
                    mailMessage.To = new Address(item.Address);
                    mailMessage.Subject = MessageToSend.MessageConfig["Subject"];
                    mailMessage.Body = MessageToSend.MessageConfig["Body"];
                    mailMessage.IsBodyHtml = true;
                    mailMessage.RequestId = Guid.NewGuid().ToString().ToUpper();

                    modelToreturn.RelatedAddress = new List<AddressModel>();
                    modelToreturn.RelatedAddress.Add(item);

                    //Envia a la cola de Mailman
                    messageQueue.Send(mailMessage, MessageQueueTransactionType.Single);                  
                }
                catch (Exception err)
                {
                    modelToreturn.isSuccess = false;
                    if (!string.IsNullOrEmpty(err.InnerException.Message))                    
                        modelToreturn.MessageResult = err.Message + " " + err.InnerException.Message;
                    else
                        modelToreturn.MessageResult = err.Message + " ";                   
                }
            }
            modelToreturn.Agent = MessageToSend.AddressToSend.FirstOrDefault().Agent;
            modelToreturn.BodyMessage = MessageToSend.MessageConfig["Body"];
            modelToreturn.MessageType = MessageToSend.MessageConfig["Subject"];
            modelToreturn.TimeSent = DateTime.Now;
            modelToreturn.isSuccess = true;
            return modelToreturn;
        }
        #endregion

        #region Funciones Publicas

        /// <summary>
        /// Funcion que valida si la dirección de sms a la que se va a enviar existe, de no ser así, la crea.
        /// </summary>
        /// <param name="address">Dirección a validar</param>
        /// <param name="agent">Medio de envio(Inalambria, Infobip,...)</param>
        /// <returns>Lista de direcciones</returns>
        private List<AddressModel> UpsertAddress(string address, string agent)
        {
            List<AddressModel> addressList = new List<AddressModel>();
            return addressList = this._controller.UpsertAddress(address, agent);
        }

        /// <summary>
        /// Funcion que envia el id del mensaje que va a ser enviado
        /// </summary>
        /// <param name="MessageProcessId">id del proceso</param>
        public void AddResend(int MessageProcessId)
        {
            this._controller.AddToResendMsj(MessageProcessId);
        }
        #endregion
    }
}

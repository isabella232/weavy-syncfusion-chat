using System;
using System.Collections.Generic;
using System.Text;

namespace WeavySyncfusionChat.Core.Models
{
    public class GenericMessageSender
    {
        private static GenericMessageSender _instance = null;

        public static GenericMessageSender Instance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new GenericMessageSender();
                }

                return _instance;
            }
        }
    }
}

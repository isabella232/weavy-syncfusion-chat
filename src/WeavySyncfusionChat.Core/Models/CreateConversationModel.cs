using System;
using System.Collections.Generic;
using System.Text;

namespace WeavySyncfusionChat.Core.Models
{
    public class CreateConversationModel
    {
        /// <summary>
        /// The name of the conversation
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The users/members of the conversation
        /// </summary>
        public List<int> Members { get; set; }
    }
}

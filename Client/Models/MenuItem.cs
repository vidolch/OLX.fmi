namespace Client.Models
{
    using Client.Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Reflection;

    class MenuItem : IMenuItem
    {
        private string text;
        private int activator;
        private string action;
        private string actionNamespace;
        private string actionClass;
        private string actionMethod;

        public MenuItem(string text, int activator, string action)
        {
            this.Text = text;
            this.Activator = activator;
            this.Action = action;
        }

        public string Text
        {
            get { return text; }
            private set { text = value; }
        }
        
        public int Activator
        {
            get { return activator; }
            private set { activator = value; }
        }


        public string Action
        {
            get { return action; }
            private set {
                this.action = value;

                string[] arr = this.action.Split('@');

                this.actionNamespace = arr[0];
                this.actionClass = arr[1];
                this.actionMethod = arr[2];
            }
        }


        public void Call()
        {

            var classType = Type.GetType(this.actionNamespace + "." + this.actionClass);
            var action = System.Activator.CreateInstance(classType);
            MethodInfo method = classType.GetMethod(this.actionMethod);
            method.Invoke(action, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ENTITY;
using DALL;

namespace BLL
{
    public class Service
    {
        private Repository _Neurona { get; set; }
        public Service()
        {
            _Neurona = new Repository();
        }
        public Red LeerXml(string Path)
        {
            return _Neurona.LeerXml(Path);
        }
    }
}

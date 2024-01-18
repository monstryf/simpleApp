using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.ModelTest
{
    public class ErrorLogger
    {
        public  string LastError { get; set; }
        public event EventHandler<Guid> ErrorLogged;
        private Guid _errorId;
        public void Log(string error)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                throw new ArgumentNullException();
            }
            LastError = error; 
            _errorId = Guid.NewGuid();
            OnErrorLogged(_errorId  );
        }
        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId); 
        }

    }
}

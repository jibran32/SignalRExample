using Ais.Agent.Executor.Service.Services.CommunicationService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ais.Agent.Executor.Service
{
    public partial class Service1 : ServiceBase
    {
        private SignalRClientService _signalRClientService;
        public Service1()
        {
            InitializeComponent();
            _signalRClientService = new SignalRClientService();
        }

        protected override void OnStart(string[] args)
        {
            _signalRClientService.Start().GetAwaiter().GetResult();
        }

        protected override void OnStop()
        {
            _signalRClientService.Stop().GetAwaiter().GetResult();
        }
    }
}

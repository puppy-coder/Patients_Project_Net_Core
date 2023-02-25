using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Persistence;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class List
    {
        public class Query : IRequest<List<Domain.Patients>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Domain.Patients>>
        {
            
            private readonly IMediator _mediator;
            private readonly IHostingEnvironment _hostingEnvironment;

            public Handler( IMediator mediator, IHostingEnvironment hostingEnvironment)
            {
               
                _mediator = mediator;
                _hostingEnvironment = hostingEnvironment;
            }

            public async Task<List<Domain.Patients>> Handle(Query request, CancellationToken cancellationToken)
            {
                   using (StreamReader r = new StreamReader("D:\\Patients_Project_Net_Core\\Domain\\Patients.json"))
            {
                string json = r.ReadToEnd();
                List<Patients> item = JsonConvert.DeserializeObject<List<Patients>>(json);
                return item;
            }
        

        
                   
            }
        }
    }
}




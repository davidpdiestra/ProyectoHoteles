﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente
{
    public class CrearClienteCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}

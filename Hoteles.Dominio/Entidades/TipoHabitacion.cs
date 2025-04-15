﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class TipoHabitacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public bool Activo { get; set; }
        public ICollection<Habitacion> Habitaciones { get; set; }

    }
}

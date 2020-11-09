﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }


        public Categoria(int id, string desc)
        {
            Id = id;
            Descripcion = desc;

        }

        public Categoria() { }

        public override string ToString()
        {
            return Descripcion;
        }


    }
}

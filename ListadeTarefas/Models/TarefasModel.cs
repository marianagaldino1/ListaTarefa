﻿using System.ComponentModel.DataAnnotations;

namespace ListadeTarefas.Models
{
    public class TarefasModel
    {
        public int Id_Tarefa { get; set; }

        public string NomeTarefa { get; set; }

        public decimal CustoTarefa { get; set; }

        public DateTime DataLimite { get; set; }


        public int Ordem { get; set; }
    }
}

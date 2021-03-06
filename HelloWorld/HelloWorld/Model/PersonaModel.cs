﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld.Model
{

    public class PersonaModel:INotifyPropertyChanged

    {
        private string id;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }


        public bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy = false; }
            set { isBusy = value; OnPropertyChanged(); }
        }


        public string Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged();
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(); OnPropertyChanged(nameof(NombreCompleto)); }
        }


        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; OnPropertyChanged(); OnPropertyChanged(nameof(NombreCompleto)); }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; OnPropertyChanged(); }
        }


        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
            set { nombreCompleto = value; OnPropertyChanged(nameof(Mensaje)); }
        }

        public string Mensaje
        {
            get { return $"Tu nombre es: {NombreCompleto}"; }
        }


    }
}

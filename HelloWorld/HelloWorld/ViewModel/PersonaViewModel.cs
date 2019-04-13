using HelloWorld.Model;
using HelloWorld.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.ViewModel
{
    public class PersonaViewModel:PersonaModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonaModel modelo;

        public PersonaViewModel()
        {
            Personas = servicio.getAll();
            SaveCommand = new Command(async () => await Save(), () => !IsBusy);
            UpdateCommand = new Command(async () => await Update(), () => !IsBusy);
            RemoveCommand = new Command(async () => await Delete(), () => !IsBusy);
            CleanCommand = new Command(Clean, () => !IsBusy);
        }

        public Command SaveCommand { get; set; }

        public Command UpdateCommand { get; set; }

        public Command RemoveCommand { get; set; }

        public Command CleanCommand { get; set; }

        private async Task Save()
        {
            IsBusy = true;
            Guid IdPersona = Guid.NewGuid();
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = IdPersona.ToString()
            };

            servicio.save(modelo);
            IsBusy = false;
        }

        private async Task Update()
        {
            IsBusy = true;
            modelo = new PersonaModel()
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id
            };

            servicio.update(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            servicio.delete(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clean()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }
    }
}

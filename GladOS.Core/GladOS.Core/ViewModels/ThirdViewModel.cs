using GladOS.Core.Models;
using GladOS.Core.Services;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace GladOS.Core.ViewModels
{
    public class ThirdViewModel : MvxViewModel
    {

        public ThirdViewModel()
        {
            
            //Nav buttons
            HomePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<SecondViewModel>();
            });

            SchedulePressed = new MvxCommand(() =>
            {
                base.ShowViewModel<FirstViewModel>();
            });

            SearchPressed = new MvxCommand(() =>
            {
                base.ShowViewModel<ThirdViewModel>();
            });

            SelectedPerson = new MvxCommand<Person>(selectedPerson => 
                                            base.ShowViewModel<FourthViewModel>(selectedPerson));

            //Create people
            var newList = new List<Person>();
            PersonServices personServices = new PersonServices();
            for (var i = 0; i < 22; i++)
            {
                Person newPerson = new Person();
                newPerson = personServices.CreatePerson(personNames[i], personNumber[i], personImages[i], "Telstra", personEmail[i]);
                newList.Add(newPerson);
            }

            Persons = newList;
        }

        public ICommand HomePressed { get; private set; }
        public ICommand SchedulePressed { get; private set; }
        public ICommand SearchPressed { get; private set; }
        public ICommand SelectedPerson { get; private set; }

        private List<Person> persons;
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(() => Persons); }
        }

        // references to our images
        string[] personImages = 
        {
        "sample_2", "sample_3",
        "sample_4", "sample_5",
        "sample_6", "sample_7",
        "sample_0", "sample_1",
        "sample_2", "sample_3",
        "sample_4", "sample_5",
        "sample_6", "sample_7",
        "sample_0", "sample_1",
        "sample_2", "sample_3",
        "sample_4", "sample_5",
        "sample_6", "sample_7"
        };

        // Person Names
        string[] personNames =
        {
            "John Wayne", "Bruce Wayne",
            "Paul Smith", "Eric Banner",
            "Simon Pegg", "Clarke Kent",
            "Julius Ceasar", "Floyd Pink",
            "Suan White", "Eddie Eel",
            "Doc Martin", "Plain Jane",
            "John Doe", "Sarah Shizzle",
            "Brian Blessed", "Bruce Lee",
            "Haratio Nelson", "Hugh Trenchard",
            "Isambard Kingdom Brunel", "Fritz Haber",
            "Manfred von Richthofen", "Andy Penn",
        };

        // Phone Numbers
        string[] personNumber =
        {
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
            "0430220628","0430220628",
        };

        // Phone Numbers
        string[] personEmail =
        {
            "JohnWayneEmail@Email.com","DarkKnightEmail@Email.com",
            "PaulSmithEmail@Email.com","EricBEmail@Email.com",
            "SimonPeggEmail@Email.com","SuperEmail@Email.com",
            "JuliusCeasarEmail@Email.com","FloydEmail@Email.com",
            "SuanWhiteEmail@Email.com","SwimEmail@Email.com",
            "DocMartinEmail@Email.com","BoringEmail@Email.com",
            "JohnDoeEmail@Email.com","ShizEmail@Email.com",
            "BBlessedEmail@Email.com","FighterEmail@Email.com",
            "HNelsonEmail@Email.com","LordTEmail@Email.com",
            "BrunelEmail@Email.com","FritzEmail@Email.com",
            "RedBaronEmail@Email.com","APennEmail@Email.com",
        };
    }
}
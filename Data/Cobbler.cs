using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit { get; set; }


        private bool withIceCream = true;
        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get { return withIceCream; }
            set 
            {
                withIceCream = value;
                NotifyOfPropertyChanges(new List<string>() { "WithIceCream", "SpecialInstructions" });
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream)
                {
                    NotifyOfPropertyChanges(new List<string>() { "Price" });
                    return 5.32;
                }
                else
                {
                    NotifyOfPropertyChanges(new List<string>() { "Price" });
                    return 4.25;
                }
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { NotifyOfPropertyChanges(new List<string>() { "SpecialInstructions" }); return new List<string>(); }
                else { NotifyOfPropertyChanges(new List<string>() { "SpecialInstructions" });  return new List<string>() { "Hold Ice Cream" }; }
            }
        }


       private void NotifyOfPropertyChanges(List<string> propertiesChanged)
        {
            foreach (string proprty in propertiesChanged)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprty));
            }
        }
    }
}

using System;
using System.Reflection;

namespace Questions.Interviews_CSharp.DesignPatterns.Creation
{

	#region Interface
	public interface IAuto {
		string Name {get;}
		void TurnOn();
		void TurnOff();
	}
    #endregion

    #region Derived class
    public class Peugeot : IAuto
    {
        public string Name => "Peugeot";

        public void TurnOff() => Console.WriteLine("Peugeot Off");

        public void TurnOn() => Console.WriteLine("Peugeot On");
    }
    public class Renault : IAuto
    {
        public string Name => "Renault";

        public void TurnOff() => Console.WriteLine("Renault Off");

        public void TurnOn() => Console.WriteLine("Renault On");
    }
    #endregion

    #region Factory class
    public class Factory
    {
        public static IAuto CreateAuto(string name)
        {
            var objectType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == name && t.IsAssignableFrom(t)) ??
                throw new ArgumentOutOfRangeException(nameof(IAuto), $"this factory cannot handle {name}");
            return (IAuto)Activator.CreateInstance(objectType);
        }
    }
    #endregion

}


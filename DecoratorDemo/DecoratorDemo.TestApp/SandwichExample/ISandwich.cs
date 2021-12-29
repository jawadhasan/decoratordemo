using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo.TestApp.SandwichExample
{
    //Component
    public interface ISandwich
    {
        public string Make();
    }

    //Concrete Component
    public class SimpeSandwich : ISandwich
    {
        public string Make()
        {
            return "Bread";
        }
    }

    //Decorator
    public abstract class SandwichDecortaor : ISandwich
    {
        protected readonly ISandwich _innerSandwich;
        public SandwichDecortaor(ISandwich innerSandwich)
        {
            _innerSandwich = innerSandwich;
        }
        public virtual string Make()
        {
            return _innerSandwich.Make();
        }
    }

    //Concrete Decotorator #1
    public class MeatDecorator : SandwichDecortaor
    {
        public MeatDecorator(ISandwich innerSandwich):
            base(innerSandwich)
        {
        }
        public override string Make()
        {
            return $" {_innerSandwich.Make()} Turkey";
        }
    }

    //Concrete Decotorator #2
    public class DressingDecorator : SandwichDecortaor
    {
        public DressingDecorator(ISandwich innerSandwich) :
            base(innerSandwich)
        {
        }
        public override string Make()
        {
            return $" {_innerSandwich.Make()} Mustard";
        }
    }
}

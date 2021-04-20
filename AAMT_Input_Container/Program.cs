using System;

namespace AAMT_Input_Container
{
    class Program
    {
        static void Main(string[] args)
        {
            Input AAMT_STRING = new Input("Hello World!");
            Console.WriteLine( AAMT_STRING.step(4).step().step().jumpForward(7) );
        }
    }

    public class Input
    {
        private readonly string input;
        private readonly int length;
        private int position;
        private int lineNumber;
        //Properties
        public int Length
        {
            get
            {
                return this.length;
            }
        }
        public int Position
        {
            get
            {
                return this.position;
            }
        }
        public int NextPosition
        {
            get
            {
                return this.position + 1;
            }
        }
        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }
        public char Character
        {
            get
            {
                if (this.position > -1) return this.input[this.position];
                else throw new Exception("Error current position less than zero");
            }
        }
        public Input(string input)
        {
            this.input = input;
            this.length = input.Length;
            reset();
        }

        public bool hasMore(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return checked (this.position + numOfSteps) < this.length;
        }
        public bool hasLess(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (this.position - numOfSteps) > -1; // -2  -2147483647
        }
        //callback -> delegate
        public Input step(int numOfSteps = 1)
        {
            if (this.hasMore(numOfSteps))
                this.position += numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input back(int numOfSteps = 1)
        {
            if (this.hasLess(numOfSteps))
                this.position -= numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input reset()
        {

            this.position = -1;
            this.lineNumber = 1;

            return this;
        }

        public char peek(int numOfSteps = 1)
        {

            if (this.hasMore(numOfSteps))
            {
                return this.input[this.Position + numOfSteps];
            }

            return '\0';
        }

        public string jumpForward(uint numOfChar)
        {
            string result = "" + this.Character;
            for (int i = 1; i < numOfChar; i++)
            {
                result += this.step().Character;
            }
            return result;
        }

        public string jumpBackward(uint numOfChar)
        {
            string result = "" + this.Character;
            for (int i = 1; i < numOfChar; i++)
            {
                result = this.back().Character + result;
            }
            return result;
        }

        // public string combine() { return ""; } // take cp + np and return as string
        // combine() == "//"
        // middle index 
        // filter 
        // clone
        // fixed chunks
        // reverse 
        // first char in a word 
    }
}

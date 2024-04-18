// See https://aka.ms/new-console-template for more information

using Events;

TextBox textBox = new TextBox();
textBox.OnTextChanged += PrintText;

textBox.AddText("Hasan");

void PrintText(string text)
{
    Console.WriteLine(text);
}

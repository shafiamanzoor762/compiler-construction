
# 🧠 Compiler Construction Project (C# Windows Forms)

## 📌 Overview

This project is a custom-built **compiler simulation** implemented using **C# Windows Forms**. It parses and evaluates a custom-designed scripting language that supports **variables**, **conditional logic**, **loops**, **arrays**, and **I/O operations**.

The compiler scans input code, validates it using **Regular Expressions (Regex)**, and simulates the compilation process with basic **syntax analysis**, **semantic checks**, **symbol table generation**, and **intermediate interpretation**.

---

## 🛠️ Features

* 🧾 **Lexical Analysis** using Regex.
* 📄 **Syntax Analysis** with grammar-based validation.
* 📚 **Symbol Table** management with scope support.
* 💡 **Conditional Logic**: `is`, `elis`, `el` constructs (similar to if-else).
* 🔁 **Looping** using a `loop(...)` construct.
* 📦 **Array Declaration** with basic initialization.
* 🖨️ **Display Statements** (string, variable, expressions).
* ⌨️ **Input Statements**.
* ➕ **Arithmetic Expressions**: supports `+`, `-`, `*`, `/` operators.
* 🧮 **Expression Evaluation**.
* 🧪 **Switch-Case-like** structure using `option()`, `opt`, `def`.

---

## 🧪 Sample Code Inputs

Here are some supported code patterns:

```plaintext
num $a = 10, $y;
display < $a;
{
    num $x = 7;
    display < $x;
    $y = 50;
}
display < $y;

num $a = 2;
num $b = 5;
is($a > $b){
    display < 'a is greater';
}
elis($a < $b){
    display < 'a is less';
}
el{
    display < 'a is equal to b';
}
```

---

## 🧰 Technology Stack

| Component      | Technology        |
| -------------- | ----------------- |
| Language       | C#                |
| UI Framework   | Windows Forms     |
| Logic Handling | Regex, C# Classes |
| IDE            | Visual Studio     |

---

## 🧩 Supported Syntax

### ✅ Declarations

```plaintext
num $x;
flo $y;
chr $z;
str $name;
```

### ✅ Initialization

```plaintext
$x = 5;
$name = "John";
```

### ✅ Declaration + Initialization

```plaintext
num $a = 10;
flo $rate = 3.14;
chr $grade = 'A';
```

### ✅ Multiple Declarations / Initializations

```plaintext
num $x = 5, $y, $z;
flo $a, $b;
```

### ✅ Arithmetic Expressions

```plaintext
$a = 5 + 3;
$x = $y * 2 - 1;
```

### ✅ Display Statements

```plaintext
display < 'Hello World';
display < $x;
display < 'Value: ' + $x;
```

### ✅ Input Statements

```plaintext
in > $name;
```

### ✅ Conditional Statements

```plaintext
is($x > $y){
    ...
}
elis($x == $y){
    ...
}
el{
    ...
}
```

### ✅ Looping

```plaintext
loop(num $i = 0; $i < 10; $i + 1){
    display < $i;
}
```

### ✅ Arrays

```plaintext
num $arr = new num[1, 2, 3, 4];
```

### ✅ Option Block (Switch-Case)

```plaintext
option($choice){
    opt 1:
        display < 'One';
    opt 2:
        display < 'Two';
    def:
        display < 'Default';
}
```

---

## 🗂️ Project Structure

```plaintext
CompilerProject/
├── MainForm.cs        # Main UI logic with Regex-based parsing
├── SymbolTable.cs     # Class to store variable name, type, and value
├── ScopeSymbolTable.cs# For nested block-level scoping
├── CompilerEngine.cs  # Core logic (semantic analysis, evaluation)
├── RegexPatterns.cs   # Regex definitions for grammar
├── Program.cs         # App entry point
├── CC.sln
└── README.md
```

---

## 🧪 Symbol Table Design

| Name | Type | Value | Scope  |
| ---- | ---- | ----- | ------ |
| \$a  | num  | 10    | global |
| \$x  | num  | 7     | local  |

---

## 💡 Implementation Highlights

* **Modular Regex Rules**:

  * Different patterns for declaration, initialization, arithmetic, loops, and conditionals.
* **Queue-based Execution**:

  * Instructions are parsed and added to a queue for simulation.
* **Block Management**:

  * Scope-sensitive parsing for nested code blocks.
* **Extensible Design**:

  * Easily add support for new types and language constructs.

---

## 🔄 How to Run

1. Clone or download the project.
2. Open in **Visual Studio**.
3. Restore NuGet packages if required.
4. Press `Start` (F5) to run the Windows Form app.
5. Paste example code in the `txtInput` textbox.
6. Press the `Compile` or `Run` button (ensure you have that button wired to parsing logic).

---

## 📈 Future Enhancements

* ✅ Add error highlighting and messages.
* ✅ GUI improvements with syntax highlighting.
* ⏳ AST (Abstract Syntax Tree) generation.
* ⏳ Intermediate Code Generation (ICG).
* ⏳ Basic optimization strategies.
* ⏳ Function support and recursion.
* ⏳ Export symbol table to file.

---

## 👨‍🏫 Educational Value

This project was created as part of a **Compiler Construction** course to simulate the fundamental concepts of:

* Lexical & Syntactic analysis
* Context-free grammar validation
* Symbol tables and scoping
* Expression evaluation and control flow

---

## 📄 License

This project is for educational and academic use only. All rights reserved © 2025.

---

## 🙋 Contact

For questions or suggestions, feel free to contact the developer:

**Name:** [Shafia Manzoor](https://github.com/shafiamanzoor762)
**LinkedIn:** [linkedin.com/in/yourprofile](https://www.linkedin.com/in/shafia-manzoor-0b9596272/)

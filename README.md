<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UML Diagram</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
        }
        .class-box {
            border: 1px solid #444;
            border-radius: 5px;
            margin: 20px auto;
            padding: 10px;
            width: 300px;
            background-color: #fff;
            box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.1);
        }
        .class-title {
            background-color: #444;
            color: #fff;
            font-weight: bold;
            text-align: center;
            padding: 5px;
            border-radius: 3px 3px 0 0;
        }
        .attributes, .methods {
            padding: 10px;
        }
        .relation {
            text-align: center;
            margin: 10px 0;
            font-style: italic;
        }
        hr {
            border: none;
            border-top: 1px solid #ccc;
        }
    </style>
</head>
<body>

    <div class="class-box">
        <div class="class-title">User</div>
        <div class="attributes">
            <b>Attributes:</b>
            <ul>
                <li>- name: string</li>
                <li>- surname: string</li>
                <li>- email: string</li>
                <li>- hashedPassword: string</li>
                <li>- mobile: string</li>
            </ul>
        </div>
        <hr>
        <div class="methods">
            <b>Methods:</b>
            <ul>
                <li>+ password: string</li>
                <li>+ ValidatePassword(inputPassword: string): bool</li>
                <li>- HashPassword(password: string): string</li>
            </ul>
        </div>
    </div>

    <div class="class-box">
        <div class="class-title">Product</div>
        <div class="attributes">
            <b>Attributes:</b>
            <ul>
                <li>- code: string</li>
                <li>- name: string</li>
                <li>- precio: string</li>
            </ul>
        </div>
        <hr>
        <div class="methods">
            <b>Methods:</b>
            <ul>
                <li>+ IsValidPrice(): bool</li>
            </ul>
        </div>
    </div>

    <div class="class-box">
        <div class="class-title">Auth</div>
        <div class="attributes">
            <b>Attributes:</b>
            <ul>
                <li>- users: List&lt;User&gt;</li>
            </ul>
        </div>
        <hr>
        <div class="methods">
            <b>Methods:</b>
            <ul>
                <li>+ login(email: string, password: string): bool</li>
                <li>+ logout(): void</li>
            </ul>
        </div>
    </div>

    <div class="class-box">
        <div class="class-title">Handler</div>
        <div class="attributes">
            <b>Attributes:</b>
            <ul>
                <li>- listProducts: List&lt;Product&gt;</li>
                <li>- cart: List&lt;Product&gt;</li>
            </ul>
        </div>
        <hr>
        <div class="methods">
            <b>Methods:</b>
            <ul>
                <li>+ init(): void</li>
                <li>- menuMain(): void</li>
                <li>- showProducts(): void</li>
                <li>- showCart(): void</li>
                <li>- removeFromCart(): void</li>
                <li>- buyProducts(): void</li>
            </ul>
        </div>
    </div>

    <div class="class-box">
        <div class="class-title">Program</div>
        <div class="methods">
            <b>Methods:</b>
            <ul>
                <li>+ Main(args: string[]): void</li>
            </ul>
        </div>
    </div>

    <div class="relation">
        <p><b>Relations:</b></p>
        <p>Handler uses Product and Auth.</p>
        <p>Auth manages a list of User.</p>
    </div>
</body>
</html>

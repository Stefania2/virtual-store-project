# Diagrama UML del Proyecto

## Clases

### **User**
- **Atributos:**
  - `name: string`
  - `surname: string`
  - `email: string`
  - `hashedPassword: string` (privado)
  - `mobile: string`

- **Métodos:**
  - `+ password: string`
  - `+ ValidatePassword(inputPassword: string): bool`
  - `- HashPassword(password: string): string`

---

### **Product**
- **Atributos:**
  - `code: string`
  - `name: string`
  - `precio: string`

- **Métodos:**
  - `+ IsValidPrice(): bool`

---

### **Auth**
- **Atributos:**
  - `users: List<User>`

- **Métodos:**
  - `+ login(email: string, password: string): bool`
  - `+ logout(): void`

---

### **Handler**
- **Atributos:**
  - `listProducts: List<Product>`
  - `cart: List<Product>`

- **Métodos:**
  - `+ init(): void`
  - `- menuMain(): void`
  - `- showProducts(): void`
  - `- showCart(): void`
  - `- removeFromCart(): void`
  - `- buyProducts(): void`

---

### **Program**
- **Métodos:**
  - `+ Main(args: string[]): void`

---

## Relaciones
- `Handler` usa `Product` y `Auth`.
- `Auth` gestiona una lista de `User`.

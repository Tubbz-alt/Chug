# Chug

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Chug is an unconventional symmetric cipher in which both the plaintext and the ciphertext are defined in order to be used to create a key that mathematically links the two values together. This allows a user to define what the displayed message would be while maintaining the ability to securely transmit the key through the use of a complimentary asymmetric cipher. The only requirement of the cipher is that the size of the ciphertext be equal to or larger than the size of the plaintext.

## Sugguestions & Bug Reports

If you would like to suggest a feature or report a bug please see the [issues](https://github.com/sblmnl/Chug/issues) page.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Requirements

* **Visual Studio IDE** - [https://visualstudio.microsoft.com](https://visualstudio.microsoft.com)

### Compiling
```
1. Open "Chug.sln" with the Visual Studio IDE
2. Navigate to the "Chug" project in the solution explorer
3. Build (Menu Bar: Build > Build Chug)
```

## Equations

* **Mapping ("Encryption")**
       - `p - c % 256 = k`
* **Morphing ("Decryption")**
       - `c + k % 256 = p`
* **Variable Definitions**
       - `p :   The variable that represents the plaintext value.`
       - `c :   The variable that represents the ciphertext value.`
       - `k :   The variable that represents the key value.`

## Authors

* **Developer** - [sblmnl](https://github.com/sblmnl)

See also the list of [contributors](https://github.com/sblmnl/Chug/contributors) who participated in this project.

## License

This project is licensed under the MIT license - see the [LICENSE](LICENSE) file for details
# Chug

[![License](https://img.shields.io/badge/license-GPLv3-blue.svg)](LICENSE)

Chug is an unconventional symmetric cipher in which the ciphertext is used to map a message into a key value that defines how the ciphertext can be read in order to reveal the plaintext message. The only requirement of the cipher is that the size of the ciphertext be equal to or larger than the size of the plaintext. Chug very closely resembles the [One-time pad](https://en.wikipedia.org/wiki/One-time_pad) encryption technique, but differs in mathematic operation and in the use of the key.

## Sugguestions & Bug Reports

If you would like to suggest a feature or report a bug please see the [issues](https://github.com/sblmnl/Chug/issues) page.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Requirements

* **Visual Studio IDE** - [https://visualstudio.microsoft.com](https://visualstudio.microsoft.com)

### Compiling
```
1. Open "src/ChugCipher.sln" with the Visual Studio IDE
2. Navigate to the "ChugCipher" project in the solution explorer
3. Build (Menu Bar: Build > Build ChugCipher)
```

## Authors

* **Developer** - [sblmnl](https://github.com/sblmnl)

See also the list of [contributors](https://github.com/sblmnl/Chug/contributors) who participated in this project.

## License

This project is licensed under the GNU GPLv3 license - see the [LICENSE](LICENSE) file for details
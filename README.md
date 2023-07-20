# CypherImage

```
byte[] bytesOriginal = Convert.FromBase64String(base64Original);

byte[] bytesEncrypted = CypherImageLibrary.Encrypt(bytesOriginal, "rohan");
string base64Encrypted = Convert.ToBase64String(bytesEncrypted);

byte[] bytesDecrypted = CypherImageLibrary.Decrypt(bytesEncrypted, "rohan");
string base64Decrypted = Convert.ToBase64String(bytesDecrypted);
```

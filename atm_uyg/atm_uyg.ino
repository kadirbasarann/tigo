#include <SPI.h>
#include <MFRC522.h>
#include <Servo.h>
#include <Keypad.h>
#include <LiquidCrystal_I2C.h>
// Örnekler oluştur
LiquidCrystal_I2C lcd(0x27, 16, 2);
MFRC522 mfrc522(10, 9); 
//MFRC522 mfrc522(SS_PIN, RST_PIN)
Servo sg90;
// Led'ler, servolar ve buzzer için Pinleri başlat
// Mavi LED 5V'a bağlanır5V
constexpr uint8_t greenLed = 7;
constexpr uint8_t redLed = 6;
constexpr uint8_t servoPin = 8;
constexpr uint8_t buzzerPin = 5;
char initial_password[4] = {'1', '2', '1', '8'};// İlk şifreyi saklayacak değişken  
String tagUID = "E9 8A 55 B2";  // Etiketin UID'sini saklayacak dize. Etiketinizin UID'si ile değiştirin
char password[4];   // Kullanıcı şifresini saklayacak değişken
boolean RFIDMode = true; // modları değiştirmek için boole
char key_pressed = 0; // Gelen anahtarları saklamak için değişken
uint8_t i = 0;  // Sayaç için kullanılan değişken
// tuş takımımızda kaç satır ve sütun olduğunu tanımlamahave
const byte rows = 4;
const byte columns = 4;
// Tuş takımı pin haritası
char hexaKeys[rows][columns] = {
  {'1', '2', '3', 'A'},
  {'4', '5', '6', 'B'},
  {'7', '8', '9', 'C'},
  {'*', '0', '#', 'D'}
};
// Tuş takımı için pinleri başlatma
byte row_pins[rows] = {A0, A1, A2, A3};
byte column_pins[columns] = {2, 1, 0};
// Tuş takımı için örnek oluştur
Keypad keypad_key = Keypad( makeKeymap(hexaKeys), row_pins, column_pins, rows, columns);
void setup() {
 // Arduino Pin konfigürasyonu
  pinMode(buzzerPin, OUTPUT);
  pinMode(redLed, OUTPUT);
  pinMode(greenLed, OUTPUT);
  sg90.attach(servoPin);//Servo için pin 8'i bildir
  sg90.write(0); // Başlangıç ​​konumunu 90 derecede ayarla
  lcd.init();   // LCD ekran
  lcd.backlight();
  SPI.begin();      // Init SPI bus
  mfrc522.PCD_Init();   // Init MFRC522
  lcd.clear(); //  LCD ekranı sil
}
void loop() {
  // Sistem önce modu arayacak
  if (RFIDMode == true) {
    lcd.setCursor(0, 0);
    lcd.print("   BAUN ATM");
    lcd.setCursor(0, 1);
    lcd.print("Kartinizi Okutunuz");
    // Yeni kartlar ara
    if ( ! mfrc522.PICC_IsNewCardPresent()) {
      return;
    }
    // Kartlardan birini seçin
    if ( ! mfrc522.PICC_ReadCardSerial()) {
      return;
    }
    //Karttan okuma
    String tag = "";
    for (byte j = 0; j < mfrc522.uid.size; j++)
    {
      tag.concat(String(mfrc522.uid.uidByte[j] < 0x10 ? " 0" : " "));
      tag.concat(String(mfrc522.uid.uidByte[j], HEX));
    }
    tag.toUpperCase();
    //Kart kontrol ediliyor
    if (tag.substring(1) == tagUID)
    {
      // Etiketin UID'si eşleşirse.
      lcd.clear();
      lcd.print("Kart Okundu");
      digitalWrite(greenLed, HIGH);
      digitalWrite(buzzerPin, HIGH);
      delay(3000);
      digitalWrite(greenLed, LOW);
      digitalWrite(buzzerPin, LOW);
      lcd.clear();
      lcd.print("Sifrenizi Girin");
      lcd.setCursor(0, 1);
      RFIDMode = false; // RFID modunu yanlış yap
    }
    else
    {
      // Etiketin UID'si eşleşmezse.
      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print("Wrong Tag Shown");
      lcd.setCursor(0, 1);
      lcd.print("Access Denied");
      digitalWrite(buzzerPin, HIGH);
      digitalWrite(redLed, HIGH);
      delay(3000);
      digitalWrite(buzzerPin, LOW);
      digitalWrite(redLed, LOW);
      lcd.clear();
    }
  }
// RFID modu yanlış ise tuş takımından anahtarları arayacaktır.
  if (RFIDMode == false) {
    key_pressed = keypad_key.getKey(); // Anahtarları saklamak
    if (key_pressed)
    {
      password[i++] = key_pressed; // Şifre değişkeninde saklama
      lcd.print("*");
    }
    if (i == 4) // 4 tuş tamamlandıysa
    {
      delay(200);
      if (!(strncmp(password, initial_password, 4))) // Şifre eşleşirse
      {
        lcd.clear();
        lcd.print("Giris Basarali");
        sg90.write(90); // Door Opened
        digitalWrite(greenLed, HIGH);
        delay(3000);
        digitalWrite(greenLed, LOW);
        sg90.write(0); // Door Closed
        lcd.clear();
        i = 0;
        RFIDMode = true; // Make RFID mode true
      }
      else    // Şifre eşleşmezse
      {
        lcd.clear();
        lcd.print("Sifre Yanlıs");
        digitalWrite(buzzerPin, HIGH);
        digitalWrite(redLed, HIGH);
        delay(3000);
        digitalWrite(buzzerPin, LOW);
        digitalWrite(redLed, LOW);
        lcd.clear();
        i = 0;
        RFIDMode = true;  // Make RFID mode true
      }
      
    }
  }
}

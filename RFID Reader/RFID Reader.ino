/*
 * ----------------------------------
 *             MFRC522      Arduino      
 * Signal      Pin          Pin     
 * ----------------------------------
 * RST/Reset   RST          9
 * SPI SS      SDA(SS)      10
 * SPI MOSI    MOSI         11
 * SPI MISO    MISO         12
 * SPI SCK     SCK          13
 */

#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 10
#define RST_PIN 9
#define LED_PIN 2
 
MFRC522 rfid(SS_PIN, RST_PIN);

byte nuidPICC[4];  // ID'leri tutan dizi

void setup() { 
  Serial.begin(115200);  // Seri iletişim protokolünü başlat
  pinMode(LED_PIN, OUTPUT);
  for(int i=0; i<8; i++)
  {
    digitalWrite(LED_PIN, HIGH);
    delay(35);
    digitalWrite(LED_PIN, LOW);
    delay(35);
  }
  SPI.begin();     // SPI protokolünü başlat
  rfid.PCD_Init(); // MFRC522 donanımını başlat
}
 
void loop() {

  // Yeni kart okutulana kadar bekle
  if ( ! rfid.PICC_IsNewCardPresent())
    return;

  // Kartın okutulduğunu doğrula
  if ( ! rfid.PICC_ReadCardSerial())
    return;

  // Yeni okunan kart, eski okutulan karttan farklı ise
  if (rfid.uid.uidByte[0] != nuidPICC[0] || 
    rfid.uid.uidByte[1] != nuidPICC[1] || 
    rfid.uid.uidByte[2] != nuidPICC[2] || 
    rfid.uid.uidByte[3] != nuidPICC[3] ) {
    // Okunan kartın ID'sini diziye kopyala
    for (byte i = 0; i < 4; i++) {
      nuidPICC[i] = rfid.uid.uidByte[i];
    }
    digitalWrite(LED_PIN, HIGH);
    printHex(rfid.uid.uidByte, rfid.uid.size); // Okutulan kartın ID'sini seri porttan gönder
    Serial.println();
    delay(750);
    digitalWrite(LED_PIN, LOW);
  }

  // İletişimi bitir
  rfid.PICC_HaltA();
  rfid.PCD_StopCrypto1();
}


/**
 * Kart ID'sini seri porttan hex olarak gönderen fonksiyon
 */
void printHex(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    Serial.print(buffer[i] < 0x10 ? "0" : "");
    Serial.print(buffer[i], HEX);
  }
}

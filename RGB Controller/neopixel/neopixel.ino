#include <Adafruit_NeoPixel.h>
#include <EEPROM.h>

#define LED             13                                   // (Don't Change for Original Sonoff, Sonoff SV, Sonoff Touch, Sonoff S20 Socket)
#define PIXEL_PIN       D5
#define PIXEL_COUNT     60 

Adafruit_NeoPixel strip(PIXEL_COUNT, PIXEL_PIN, NEO_GRB + NEO_KHZ800);

int old_command = 0;
int random_active = 0;
int i = 0;
int j = 0;
int fade_in = 0;
int fade_out = 255;
int r = 255, g = 0, b = 0;
int count = 0;
int Position = 0;
int effect_direction = 1;
long firstPixelHue = 0;
int pixelHue = 0;
int color_wait = 0;
int color_level = 1;
int command = 1;
int _level = 1;
int err;

String req;
String readString;

unsigned long previousMillis = 0;        

const long interval = 8000; 

String inputString = "";
bool stringComplete = false; 

void setup() {
  EEPROM.begin(512);
  Serial.begin(115200);
  /*EEPROM.write(0, 1);   
  EEPROM.write(1, 100);  
  EEPROM.commit();*/
  
  command = EEPROM.read(0);
  _level = EEPROM.read(1);

  Serial.print("Anim: ");
  Serial.println(command);
  Serial.print("Level: ");
  Serial.println(_level);
  
  strip.begin(); // Initialize NeoPixel strip object (REQUIRED)
  strip.setBrightness(_level);
  strip.clear();
  strip.show();  // Initialize all pixels to 'off'

  // Connect to WiFi network
  
  for(int x = 0; x < 10; x++)
  {
    for(int i=0; i<strip.numPixels(); i++)
      strip.setPixelColor(i, strip.Color(127, 127, 127));
    strip.show();
    delay(30);
    strip.clear();
    strip.show();
    delay(30);
  }
}

void loop()
{
     while (Serial.available()) {
      delay(3);  //delay to allow buffer to fill
      if (Serial.available() >0) {
        char c = Serial.read();  //gets one byte from serial buffer
        readString += c; //makes the string readString
      }
    }
    if (readString.length() >0) {
      Serial.println(readString); //see what was received
      rgb_mode(readString);
      readString = "";
    }
    if(random_active == 1)
    {
      unsigned long currentMillis = millis();
      if (currentMillis - previousMillis >= interval)
      {
        previousMillis = currentMillis;
        command = random(1,10);
        while(old_command == command)
          command = random(1,10);
        old_command = command;
        Serial.println(command);
      }
    }
    if(command == 2) // color wipe
    {
      if (i<strip.numPixels())
      {
        if(color_level == 1)
          strip.setPixelColor(i, strip.Color(255,   0,   0));         //  Set pixel's color (in RAM)
        else if(color_level == 2)
          strip.setPixelColor(i, strip.Color(0,   255,   0));         //  Set pixel's color (in RAM)
        else if(color_level == 3)
          strip.setPixelColor(i, strip.Color(0,   0,   255));         //  Set pixel's color (in RAM)
        strip.show();                          //  Update strip to match
        delay(30);                           //  Pause for a moment
        i++;
      }
      else
      {
        i = 0;
        color_level++;
        if(color_level == 4)
          color_level = 1;
      }
    }
    else if(command == 1) // rainbow
    {
      if(firstPixelHue < 5*65536) {
        for(int i=0; i<strip.numPixels(); i++) {
          pixelHue = firstPixelHue + (i * 65536L / strip.numPixels());
          strip.setPixelColor(i, strip.gamma32(strip.ColorHSV(pixelHue)));
        } 
        strip.show(); // Update strip with new contents
        delay(10);  // Pause for a moment
        firstPixelHue += 256;
      }
      else
        firstPixelHue = 0;
    }
    else if(command == 3) // random theater
    {
      if(i<3)
      {
        strip.clear();
        for(int c=i; c<strip.numPixels(); c += 3) {
          int x = random(1,4);
          switch (x)
          {
            case 1:
              strip.setPixelColor(c, strip.Color(255,   0,   0));         //  Set pixel's color (in RAM)
              break;
            case 2:
              strip.setPixelColor(c, strip.Color(0,   255,   0));         //  Set pixel's color (in RAM)
              break;
            case 3:
              strip.setPixelColor(c, strip.Color(0,   0,   255));         //  Set pixel's color (in RAM)
              break;
          }
        }
        strip.show(); // Update strip with new contents
        delay(50);  // Pause for a moment
        i++;
      }
      else
      {
        i = 0;
        color_level++;
        if(color_level == 4)
          color_level = 1;
      }
    }
    else if(command == 4)
    {
      if(0<i && i<strip.numPixels())
      {
        strip.clear();
        i += effect_direction;
        strip.setPixelColor(i, strip.Color(255, 0, 0));   
        strip.show(); // Update strip with new contents
        delay(10);  // Pause for a moment
      }
      else
      {
        if(i == strip.numPixels())
          i -= 1;
        else if(i == 0)
          i += 1;
        effect_direction *= -1;
      }
    }
    
    else if(command == 5)
      CylonBounce(random(0, 255), random(0, 255), random(0, 255), 4, 10, 50);
      
    else if(command == 6)
    {
      if(j < strip.numPixels()*2)
      {
          Position++;
          for(int i=0; i<strip.numPixels(); i++) {
            strip.setPixelColor(i,((sin(i+Position) * 127 + 128)/255)*r,
                                  ((sin(i+Position) * 127 + 128)/255)*g,
                                  ((sin(i+Position) * 127 + 128)/255)*b);
          }
          strip.show();
          j++;
          delay(50);
      }
      else
      {
        count++;
        if(count == 1)
        {
          r = 0;
          g = 255;
          b = 0;
        }
        else if(count == 2)
        {
          r = 0;
          g = 0;
          b = 255;
        }
        else if(count == 3)
        {
          r = 255;
          g = 0;
          b = 0;
          count = 0;
        }
        j = 0;
        Position = 0;
      }
    }
    else if(command == 7)
      meteorRain(0xff,0xff,0xff,10, 64, true, 30);
    else if(command == 8)
    {
      if(i<strip.numPixels()) 
      {
        strip.setPixelColor(random(strip.numPixels()),0,0,255);
        strip.show();
        delay(100);
        i++;
      }
      else
      {
        i = 0;
        strip.clear();
      }
    }
    else if(command == 9)
    {
      if(j<3)
      {
        if(fade_in < 256) 
        { 
          switch(j) 
          { 
            case 0: 
              for(int c=0; c<strip.numPixels(); c++)
                strip.setPixelColor(c, fade_in, 0, 0);
              break;
            case 1: 
              for(int c=0; c<strip.numPixels(); c++)
                strip.setPixelColor(c, 0, fade_in, 0);
              break;
            case 2: 
              for(int c=0; c<strip.numPixels(); c++)
                strip.setPixelColor(c, 0, 0, fade_in);
              break;
          }
          fade_in++;
          strip.show();
          delay(3);
        }
        else
        {
          if(fade_out > 0) 
          { 
            switch(j) 
            { 
              case 0: 
                for(int c=0; c<strip.numPixels(); c++)
                  strip.setPixelColor(c, fade_out, 0, 0);
                break;
              case 1: 
                for(int c=0; c<strip.numPixels(); c++)
                  strip.setPixelColor(c, 0, fade_out, 0);
                break;
              case 2: 
                for(int c=0; c<strip.numPixels(); c++)
                  strip.setPixelColor(c, 0, 0, fade_out);
                break;
            }
            fade_out--;
            strip.show();
            delay(3);
          }
          else
          {
            fade_in = 0;
            fade_out = 255;
            j++;
            if(j==3)
              j = 0;
          }
        }
      }
    }
  }

void rgb_mode(String _data)
{
  int _mode;
  if (_data.indexOf("mode:") != -1)
  {
    _mode = _data.substring(_data.indexOf("mode:") + 5, _data.indexOf("mode:") + 7).toInt();
    Serial.print("mode: ");
    Serial.println(_mode);
    if (_mode != 10)
      random_active = 0;
    else
      random_active = 1;
    i = 0;
    count = 0;
    j = 0;
    r = 255;
    g = 0;
    b = 0;
    Position = 0;
    effect_direction = 1;
    color_level = 1;
    firstPixelHue = 0;
    fade_in = 0;
    fade_out = 255;
    command = _mode;
    EEPROM.write(0, command);  
    EEPROM.commit();
    Serial.print("Command: ");
    Serial.println(command);
    strip.clear();
    strip.show();
  }
  else if (_data.indexOf("level:") != -1)
  {
    _level = _data.substring(_data.indexOf("level:") + 6, _data.indexOf("level:") + 9).toInt();
    if (0 <= _level && _level <= 255)
    {
      EEPROM.write(1, _level);  
      EEPROM.commit();
      Serial.print("level: ");
      Serial.println(_level);
      strip.setBrightness(_level);
      strip.show();
    }
  }
  else if (_data.indexOf("r:") != -1 && _data.indexOf("g:") != -1 && _data.indexOf("b:") != -1)
  {
    int color_r = _data.substring(_data.indexOf("r:") + 2, _data.indexOf("g:")).toInt();
    int color_g = _data.substring(_data.indexOf("g:") + 2, _data.indexOf("b:")).toInt();
    int color_b = _data.substring(_data.indexOf("b:") + 2, _data.indexOf("x")).toInt();
    Serial.print("red: ");
    Serial.println(color_r);
    Serial.print("green: ");
    Serial.println(color_g);
    Serial.print("blue: ");
    Serial.println(color_b);
    command = -1;
    for(int i = 0; i < strip.numPixels(); i++)
      strip.setPixelColor(i, strip.Color(color_r,   color_g,   color_b));
    strip.show();
  }
  else {
    Serial.println("invalid request");
    /*client.stop();
      return;*/
  }
}

void random_effect()
{
  if(random_active)
  {
    i = 0;
    j = 0;
    fade_in = 0;
    fade_out = 255;
    r = 255, g = 0, b = 0;
    count = 0;
    Position = 0;
    effect_direction = 1;
    firstPixelHue = 0;
    pixelHue = 0;
    color_wait = 0;
    color_level = 1;
    strip.clear();
    strip.show();
    command = random(1,10);
    while(old_command == command)
      command = random(1,10);
    old_command = command;
    Serial.println(command);
  }
}

void meteorRain(byte red, byte green, byte blue, byte meteorSize, byte meteorTrailDecay, boolean meteorRandomDecay, int SpeedDelay)
{  
  strip.clear();
  for(int i = 0; i < strip.numPixels()*2; i++) {

    // fade brightness all LEDs one step
    for(int j=0; j<strip.numPixels(); j++) {
      if( (!meteorRandomDecay) || (random(10)>5) ) {
        fadeToBlack(j, meteorTrailDecay );        
      }
    }
    
    // draw meteor
    for(int j = 0; j < meteorSize; j++) {
      if( ( i-j <strip.numPixels()) && (i-j>=0) ) {
        strip.setPixelColor(i-j, red, green, blue);
      } 
    }
   
    strip.show();
    delay(SpeedDelay);
  }
}

void fadeToBlack(int ledNo, byte fadeValue) {
 #ifdef ADAFRUIT_NEOPIXEL_H 
    // NeoPixel
    uint32_t oldColor;
    uint8_t r, g, b;
    int value;
    
    oldColor = strip.getPixelColor(ledNo);
    r = (oldColor & 0x00ff0000UL) >> 16;
    g = (oldColor & 0x0000ff00UL) >> 8;
    b = (oldColor & 0x000000ffUL);

    r=(r<=10)? 0 : (int) r-(r*fadeValue/256);
    g=(g<=10)? 0 : (int) g-(g*fadeValue/256);
    b=(b<=10)? 0 : (int) b-(b*fadeValue/256);
    
    strip.setPixelColor(ledNo, r,g,b);
 #endif
 #ifndef ADAFRUIT_NEOPIXEL_H
   // FastLED
   leds[ledNo].fadeToBlackBy( fadeValue );
 #endif  
}

void CylonBounce(byte red, byte green, byte blue, int EyeSize, int SpeedDelay, int ReturnDelay){

  for(int i = 0; i < strip.numPixels()-EyeSize-2; i++) {
    strip.clear();
    strip.setPixelColor(i, red/10, green/10, blue/10);
    for(int j = 1; j <= EyeSize; j++) {
      strip.setPixelColor(i+j, red, green, blue); 
    }
    strip.setPixelColor(i+EyeSize+1, red/10, green/10, blue/10);
    strip.show();
    delay(SpeedDelay);
  }

  delay(ReturnDelay);

  for(int i = strip.numPixels()-EyeSize-2; i > 0; i--) {
    strip.clear();
    strip.setPixelColor(i, red/10, green/10, blue/10);
    for(int j = 1; j <= EyeSize; j++) {
      strip.setPixelColor(i+j, red, green, blue); 
    }
    strip.setPixelColor(i+EyeSize+1, red/10, green/10, blue/10);
    strip.show();
    delay(SpeedDelay);
  }
  
  delay(ReturnDelay);
}

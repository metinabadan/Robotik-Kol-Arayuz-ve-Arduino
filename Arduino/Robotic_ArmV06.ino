#include<Servo.h> // Servo kutuphanenin tanimlanmasi

Servo servomotor1 ,servomotor2 ,servomotor3 ,servomotor4 ,servomotor5 ,servomotor6 ,servomotor7 ,servomotor8 ,servomotor9; //servolarin tanimlanmasi
  
const byte servo1 =3; // Servolarin bagli olacagi pinlerin listesi
const byte servo2 =5;
const byte servo3 =6;
const byte servo4 =9;
const byte servo5 =10;
const byte servo6 =11;
const byte servo7 =12 ;

  
byte aci1=90 ,aci2=90 ,aci3=90 ,aci4=90 ,aci5=90 ,aci6=90 ,aci7=90 ;  // Servo motorlarin acilerini ifade eden degisken 

char veri ;  // haberleşmeden gelen veri

byte basinc1 ,basincdeger1 = A0 ,basinc2 ,basincdeger2 = A1 ,basinc3 ,basincdeger3 = A2 ,basinc4 ,basincdeger4 = A3; // basinc sensörlerinden gelen veri
byte buzzer=2 , led=4 ; // uyari için kullanilacak elemanlar
    
  byte sag_don (byte a) {  // servolarin kontrol fonsiyonlari
    if(a < 180){
       
       return a+5;
      }
      else {
        return 180 ;
        }      
    }

    byte sol_don (byte a) {
    if(a > 0){
         return a-5;
      }
      else {
        return  0;
        }
    }

    void uyarikontrol() { //gelen basinc degerini isleyip ,değerlendiren fonsiyon 

    basinc1=map(analogRead(basincdeger1),0,1023,0,100); // alinan degerin, 0-180 arasi olarak tanimlanmasi
    basinc2=map(analogRead(basincdeger2),0,1023,0,100); 
    basinc3=map(analogRead(basincdeger3),0,1023,0,100); 
    basinc4=map(analogRead(basincdeger4),0,1023,0,100); 

   
    if   ( (((basinc1 >= 10) && (basinc2>= 10)) || ((basinc3>= 10) && (basinc4>= 10))) ) {
      
    digitalWrite(buzzer,HIGH);
    digitalWrite(led,HIGH);
    delay(20);
    digitalWrite(buzzer,LOW);
    digitalWrite(led,HIGH);
    delay(20);
    }

    else {
      digitalWrite(led,LOW);
      digitalWrite(buzzer,LOW);
      }
       
    /*
    if (basinc1 >= 10) {       
      
    digitalWrite(buzzer,HIGH);
    digitalWrite(led,HIGH);
    delay(20);
    digitalWrite(buzzer,LOW);
    digitalWrite(led,HIGH);
    delay(20);
    }

    else if (basinc2 >= 10) {
    digitalWrite(buzzer,HIGH);
    digitalWrite(led,HIGH);
    delay(20);
    digitalWrite(buzzer,LOW);
    digitalWrite(led,HIGH);
    delay(20);
    }

    else if (basinc3 >= 10) {
    digitalWrite(buzzer,HIGH);
    digitalWrite(led,HIGH);
    delay(20);
    digitalWrite(buzzer,LOW);
    digitalWrite(led,HIGH);
    delay(20);
    }

    else if (basinc4 >= 10) {
    digitalWrite(buzzer,HIGH);
    digitalWrite(led,HIGH);
    delay(20);
    digitalWrite(buzzer,LOW);
    digitalWrite(led,HIGH);
    delay(20);
    }
    
    else{
      digitalWrite(led,LOW);
      digitalWrite(buzzer,LOW);
      }
     
 */
   }
   
  byte tut(byte a) {  
    if(a < 180){
       
       return a+5;
       uyarikontrol();
        }
     
      else {
        return 180 ;
       uyarikontrol(); //kontrolll
    }
  }

     byte birak(byte a) {
    if(a > 0){
       
       return a-5;
      uyarikontrol();
    }
      else {
        return 180 ;
        uyarikontrol();    //kontrolll
        }
        
    }
      

void motor_hareket(char b){   // servolarin kontrol kısmı   
  
   switch (b) {

    case 'w':
    aci1 = sag_don(aci1);
    servomotor1.write(aci1);
    break;

    case 's':
    aci1=sol_don(aci1);
    servomotor1.write(aci1);
    break;
    
    case 'e':
    aci2 = sag_don(aci2);
    servomotor2.write(aci2);
    break;

    case 'd':
    aci2=sol_don(aci2);
    servomotor2.write(aci2);
    break;

    case 'r':
    aci3 = sag_don(aci3);
    servomotor3.write(aci3);
    break;

    case 'f':
    aci3=sol_don(aci3);
    servomotor3.write(aci3);
    break;

    case 't':
    aci4 = sag_don(aci4);
    servomotor4.write(aci4);
    break;

    case 'g':
    aci4=sol_don(aci4);
    servomotor4.write(aci4);
    break;

   
   case 'y':
    aci5=sag_don(aci5);
    servomotor5.write(aci5);
    break;

    case 'h':
    aci5=sol_don(aci5);
    servomotor5.write(aci5);
    break;

    case 'u':
    aci6=tut(aci6);
    servomotor6.write(aci6);
    break;

    case 'j':
    aci6=birak(aci6);
    servomotor6.write(aci6);
    break;
    
     case 'ı':
    aci7=tut(aci7);
    servomotor7.write(aci7);
    break;

   case 'k':
    aci7=birak(aci7);
    servomotor7.write(aci7);
    break;

    default:
         Serial.println("gecersiz islem");
     break;   
}
}
   
void setup() {
  Serial.begin(9600);

  servomotor1.attach(servo1); // servolara pinlerinin tanimlanmasi
  servomotor1.write(90);

  servomotor2.attach(servo2);
  servomotor2.write(90);
  
  servomotor3.attach(servo3);
  servomotor3.write(90);

  servomotor4.attach(servo4);
  servomotor4.write(90);

  servomotor5.attach(servo5);
  servomotor5.write(90);

  servomotor6.attach(servo6);
  servomotor6.write(90);

  servomotor7.attach(servo7);
  servomotor7.write(90);

 
  
}

void loop() {
  if (Serial.available()) { 
 
    veri = Serial.read();
    
    motor_hareket(veri);
    
    }
  Serial.print(aci1);
  Serial.print("/");
  Serial.print(aci2);
  Serial.print("/");
  Serial.print(aci3);
  Serial.print("/");
  Serial.print(aci4);
  Serial.print("/");
  Serial.print(aci5);
  Serial.print("/");
  Serial.print(aci6);
  Serial.print("/");
  Serial.print(basinc1);
  Serial.print("/");
  Serial.print(basinc2);
  Serial.print("/");
  Serial.print(basinc3);
  Serial.print("/");
  Serial.print(basinc4);

}

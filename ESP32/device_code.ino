// ESP32 IoT Device Code
// This code handles serial communication with the ASP.NET Core application

const int LED_PIN = 2;  // Built-in LED on most ESP32 boards
const int BUTTON_PIN = 0;  // Built-in BOOT button on most ESP32 boards

// Variables to store sensor data
float temperature = 0.0;
float humidity = 0.0;
int buttonState = 0;

void setup() {
  // Initialize serial communication
  Serial.begin(115200);
  
  // Configure pins
  pinMode(LED_PIN, OUTPUT);
  pinMode(BUTTON_PIN, INPUT);
  
  // Initial LED state
  digitalWrite(LED_PIN, LOW);
}

void loop() {
  // Check for incoming commands
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n');
    handleCommand(command);
  }
  
  // Read button state
  buttonState = digitalRead(BUTTON_PIN);
  
  // Simulate sensor readings
  temperature = random(20, 30) + random(0, 100) / 100.0;
  humidity = random(40, 60) + random(0, 100) / 100.0;
  
  // Send sensor data
  String data = String(temperature) + "," + String(humidity) + "," + String(buttonState);
  Serial.println(data);
  
  // Wait before next reading
  delay(1000);
}

void handleCommand(String command) {
  command.trim();
  
  if (command == "LED_ON") {
    digitalWrite(LED_PIN, HIGH);
    Serial.println("LED:ON");
  }
  else if (command == "LED_OFF") {
    digitalWrite(LED_PIN, LOW);
    Serial.println("LED:OFF");
  }
  else if (command == "STATUS") {
    String status = "LED:" + String(digitalRead(LED_PIN)) + 
                   ",BUTTON:" + String(buttonState) +
                   ",TEMP:" + String(temperature) +
                   ",HUM:" + String(humidity);
    Serial.println(status);
  }
} 
# Tactical-Data-Link-TDL-Simulation
Version: 1.0  
Scope: Functional simulation of the Transmit/Receive chain, encompassing Application, Security, and Physical layers.

### ---

**1\. System Architecture (Static View)**

The system is designed using **Object-Oriented Composition** ("Has-A" relationships). The architecture enforces a strict chain of command where upper layers rely on lower layers to transport data, and lower layers rely on upper layers to process data.

* **Mission Computer (Layer 7 \- Application):**  
  * *Responsibility:* Human Machine Interface (HMI) and message generation.  
  * *Constraint:* Operates only on Clear Text.  
* **Cryptographic Device (Layer 6 \- Presentation/Security):**  
  * *Responsibility:* Encryption/Decryption and Data Integrity verification.  
  * *Logic:* Rejects messages with invalid headers (Simulating Key mismatch).  
* **Radio Set (Layer 1 \- Physical):**  
  * *Responsibility:* Modulation and Interface with the Environment.  
  * *Logic:* Connects to the "Atmosphere" and pushes received signals up to Crypto.

### **2\. Interface Control Document (ICD)**

This section defines the data format passed between components.

| Interface | From | To | Data Type | Content Description |
| :---- | :---- | :---- | :---- | :---- |
| **I-01** | Mission Computer | Crypto | String | **Clear Text** (e.g., "Target Alpha") |
| **I-02** | Crypto | Radio | String | **Cipher Text** (e.g., "ahplA tegraT") with Security Header |
| **I-03** | Radio | Atmosphere | String | **Noisy Signal** (Cipher text \+ Random Character Flips) |

### **3\. Threat & Error Modeling**

The system accounts for environmental constraints defined in the "RF Propagation Path."

* **Jamming / Noise (Bit Error Rate):** Modeled via a stochastic function simulate\_atmosphere(error\_rate).  
* **Integrity Check:** The Receiver requires a specific header (:ERUCES).  
  * **Pass:** Header is intact \-\> Payload is decrypted.  
  * **Fail:** Header is corrupted \-\> Packet is dropped (Availability Loss).

### ---

### **4\. Future Development**

To expand this system further, the following will be needed:

1. **Protocol/Message Standards:** Replacing raw strings with structured binary formats (like Link-16 J-Series messages).  
2. **Timing Analysis:** Modeling the *latency* (in milliseconds) added by each processing step.


#  Gmail Junk Cleaner API

A lightweight, console-based tool (using Clean Architecture) that interacts with the Gmail API to automatically delete **spam emails** from a user's Gmail inbox.

---

## Why This Project?

While Google automatically deletes spam every 30 days, spam build-up can still clog up your Gmail and reduce performance. This tool allows users to:

-  Manually trigger spam deletion anytime
-  Clean Gmail inbox with one click
-  Stay in full control without waiting 30 days

---

## Architecture

This project uses **Clean Architecture** with the following layers:

 GmailJunkCleaner.API → Entry point (Console runner)
 GmailJunkCleaner.Domain → Interfaces
 GmailJunkCleaner.Infrastructure → Gmail API integration logic
 GmailJunkCleaner.Services → Service layer (planned)

---

##  Setup Instructions

>  Do NOT commit your Google API secrets or token to GitHub. Follow this guide instead:

### 1. Create a Google Cloud Project

- Go to [Google Cloud Console](https://console.cloud.google.com/)
- Enable the **Gmail API**
- Create **OAuth 2.0 Client Credentials** (Desktop App)
- Download the file — it will look like:
client_secret_XXXXXXXXXXXX-xxxxxxxxxxxxxxxxxxxxxxxxxxx.apps.googleusercontent.com.json

### 2. Place the File

- Put the client secret file in:

GmailJunkCleaner.API/ ← Root of the API project

- On first run, a `token.json` file will be created automatically by Google API.

---

##  How to Run

```bash
cd GmailJunkCleaner.API
dotnet run

# Work in Progress

This project is actively being developed. Planned features:

    - Logging of deleted email IDs

    - Scheduling with CRON

    - Usage analytics (optional)

    - Secret management using environment variables

# Contributions
Pull requests and feedback welcome! Feel free to fork the repo and help improve this cleaner!

# Author

Made with love by [Hlamulo Mabunda]


Let me know if you'd like me to personalize this further.

--   ------    ------   ------   ------   ------     ------  ------ ------  ------ ------  ------ ------  ------  ------  ------  ------  ------ ------ --    




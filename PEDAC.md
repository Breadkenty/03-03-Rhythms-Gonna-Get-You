## Problem --------------------------------------------------------------------

Create an console app that allows the user to store and manage a company's band, albums, (and song) information in a database.
The app should be able to:

1.  Add a new band
2.  View all the bands
3.  Add an album for a band
4.  Let a band go (update isSigned to false)
5.  Resign a band (update isSigned to true)
6.  Prompt for a band name and view all their albums
7.  View all albums ordered by ReleaseDate
8.  View all bands that are signed
9.  View all bands that are not signed

Store the data on a PostgreSQL database.

## Examples --------------------------------------------------------------------

**Main Menu**
Choose a number:

1. Add a new band
2. Add an album to a band
3. Delete a band
4. Resign a band
5. View all bands
6. View albums by band
7. View all albums
8. View all signed/unsigned bands
   Q - quit the application

**If 1:** ----------------------------------------------------------

_Add a new band menu_

1. Console: Would you like to add a band? Y/N:
   User: `Y or N keypress`

_If Y_

2.  Console: What is the name of the band? `string`
    User: `The Beatles`

3.  Console: What country is `The Beatles` from? `string`
    User: `The White Album`

4.  Console: How many members are in `The Beatles`? `int`
    User: `4`

5.  Console: What is the website URL for `The Beatles`? `string`
    User: `http://thebeatles.com`

6.  Console: What style does `The Beatles` have? `string`
    User: `Rock`

7.  Console: Is the band signed? Y/N `bool`
    User: `N`

8.  Console: Who can we contact about `The Beatles`? `string`
    User: `Brian Epstein`

9.  Console: What is `Brian Epstein`'s phone number? `string`
    User: `+41 1234 567891`

10. Console: Great, we've added `The Beatles` to the database.
    Press any key to continue...
    **Returns to the main menu**

_If N_
**Returns to the main menu**

**If 2** ----------------------------------------------------------

_Add a new album to a band menu_
Console: Would you like to add an album? Y/N:
User: `Y or N keypress`

---

_If Y_

1. Console: Which band do you want to add the album to?
   User: `The Beatles`

---

_If the band exists_

2.  Console: What is the album name?
    User: `The White Album`

3.  Console: Is it explicit? Y/N:
    User: `N`

4.  Console: When was it released? Type in this format MM/DD/YYYY
    User: `11/22/1968`

5.  Console: Great, we added `The White Album` to the band: `The Beatles`.
    Press any key to continue...
    **Returns to the main menu**

---

_If the band does not exist_

2.  Console: The band does not exist in the database
    _Add a new album to a band menu_

---

_If N_

1. **Returns to the main menu**

**If 3** ----------------------------------------------------------

_Delete a band menu_
Console: Would you like to delete a band? Y/N:
User: `Y or N keypress`

---

_If Y_

1. Console: Which band do you want to delete?
   User: `The Beatles`

---

_If the band exists_

2.  Console: Are you sure you want to delete `The Beatles`?
    User: `Y`

3.  Console: Are you reeeeeeally sure you want to delete `The Beatles` from the database?
    User: `Y`

4.  Console: We've deleted `The Beatles` from our database.
    Press any key to continue...
    **Returns to the main menu**

---

_If the band does not exist_

2.  Console: The band does not exist in the database
    _Delete a band menu_

---

_If N_

1. **Returns to the main menu**

**If 4** ----------------------------------------------------------

_Re-sign/Let go of a band menu_
Console: Would you like to sign or let go of a band? S - Sign | L - Let go | M - Main Menu:
User: `S, L, or M keypress`

---

_If S_

1. Console: Which band do you want to sign?
   User: `The Beatles`

_If the band exists_

2.  Console: Are you sure you want to sign `The Beatles`?
    User: `Y`

3)  Console: We've re-signed `The Beatles`.
    Press any key to continue...
    **Returns to the main menu**

_If the band does not exist_

2.  Console: The band does not exist in the database
    _Re-sign/Let go a band menu_

---

_If L_

1. Console: Which band do you want to let go?
   User: `The Beatles`

_If the band exists_

2.  Console: Are you sure you want to let `The Beatles` go? Y/N:
    User: `Y`

3.  Console: We've let `The Beatles` go.
    Press any key to continue...
    **Returns to the main menu**

_If the band does not exist_

2.  Console: The band does not exist in the database
    _Re-sign/Let go a band menu_

---

_If M_

1. **Returns to the main menu**

**If 5** ----------------------------------------------------------

Console: Press any key to see all the bands in the database...

The Beatles
The Rolling Stones
...

Press any key to continue...
**Returns to the main menu**

---

**If 6** ----------------------------------------------------------

_View albums by band menu_

1.  Console: Which band's albums did you want to see? Type `Menu` to get back to the main menu.
    User: `The Beatles`

_If the band exists_

2.  Here are all of the albums by `The Beatles`:

    The White Album
    Abbey Road
    Let It Be

    Press any key to continue...
    **Returns to the main menu**

_If the band does not exist_

2.  Console: The band does not exist in the database
    _View albums by band menu_

_If Menu_

2.  **Returns to the main menu**

---

**If 7** ----------------------------------------------------------

_View all albums menu_

1.  Console: Here are all of the albums and their release date. Press any key to continue...

`The White Album` was released by `The Beatles` on `11/22/1968`.
`Let It Bleed` was released by `The Rolling Stones` on `12/05/1969`.
`Let It Be` was released by `The Beatles` on `05/08/1970`.
`Sticky Fingers` was released by `The Rolling Stones` on `04/23/1971`.
...

2. Press any key to continue...
   **Returns to the main menu**

**If 8** ----------------------------------------------------------

_View all signed/unsigned bands_
Console: S - For all signed bands | U - For all unsigned bands | M - For the main menu
User: `S, U, M keypress`

_If S_

1. Console: Here are all of the signed bands in our database. Press any key to continue...

`The Rolling Stones`
`Carly Rae Jepsen`
`Sigur Ros`
`The Magnetic Fields`
`The Killers`
...

Press any key to continue...
**Returns to the main menu**

_If U_

1. Console: Here are all of the unsigned bands in our database. Press any key to continue...

`The Beatles`
`John Denver`
`Queen`
...

Press any key to continue...
**Returns to the main menu**

_If M_
**Returns to the main menu**

**If Q** ----------------------------------------------------------

**End application**

## Data structure --------------------------------------------------------------------

**Table: Bands**
_Id_ - INT SERIAL PRIMARY KEY
_Name_ - STRING NOT NULL
_CountryOfOrigin_ - STRING NOT NULL
_NumberOfMembers_ - INT
_Website_ - STRING
_Style_ - STRING NOT NULL
_IsSigned_ - BOOLEAN
_ContactName_ - STRING
_ContactPhoneNumber_ - STRING

---

## Bands.Id = Albums.BandId

**Table: Albums**
_Id_ - INT SERIAL PRIMARY KEY
_Title_ - STRING NOT NULL
_IsExplicit_ - BOOLEAN
_ReleaseDate_ - TIMESTAMP/DATETIME
_BandId_ - INT REFERENCES Band.Id

## Algorithm --------------------------------------------------------------------

Set up the data:

Link postgreSQL database to the file

Classes:

Band
int Id
string Name
string CountryOfOrigin
int NumberOfMembers
string Website
string Style
bool IsSigned
string ContactName
string ContactNumber
List<Album> Albums

Album
int Id
string Title
bool IsExplicit
DateTime ReleasedDate
int BandId

Band-DatabaseContext : DbContext
Band
Album

add Band-Database context code
bands = list of objects in the database

While applicationOpen = true

Write:

♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫
Welcome to the Rhythm's Gonnna Run You Database!
♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫♪♫

Choose an option:

1 - Add a new band
2 - Add an album to a band
3 - Delete a band
4 - Resign a band
5 - View all bands
6 - View albums by band
7 - View all albums
8 - View all signed/unsigned bands
Q - quit the application

---

**If the input is 1:**

while addingBand: true
userInput: AskForKey - "Would you like to add a band? Y/N: "

**If Y**

bandNameInput - Ask for string: "What is the name of the band?

_If the `bandNameInput` exists_
bandCountryInput - Ask for string: "What country is `bandNameInput` from?"
bandMemberAmountInput - Ask for int: "How many members are in `bandNameInput`?"
bandURLInput - Ask for string: "What is the website URL for `bandNameInput`?"
bandStyleInput - Ask for string: "What style does `bandNameInput` have?"
bandSignedInput - Ask for a key: "Is the `bandNameInput` signed? Y/N "
bandContactInput - Ask for string: "Who can we contact about `bandNameInput`?"
bandContactNumberInput - Ask for string: "What is `bandContactInput`'s number?"

Add everything into the database
context.SaveChanges

PressAnyKeyPrompt: "Great, we've added `bandNameInput` to the database."
Return to main menu - addingBand: false

_If the `bandNameInput` does not exist_
PressAnyKeyPrompt: The `bandNameInput` does not exist

**If N**
Return to main menu - addingBand: false

---

**If the input is 2:**

While addingAlbum: true
userInput: PressAKeyPrompt - "Would you like to add an album? Y/N: "

**If Y**

bandNameInput = Ask For String: "Which band do you want to add the album to?"

_If bandNameInput exists_

albumNameInput = Ask For String: "What is the album's name?"
albumExplicitInput = Ask for key: "Is the `albumNameInput` explicit?
albumReleaseDateInput = Ask for DateTime: "When was `albumNameInput` released? Enter response in the format: MM/DD/YYYY "

context.SaveChanges

PressAnyKeyPrompt: "Great, we've added `albumNameInput` to the `bandNameInput`."
Return to main menu - addingAlbum: false

_If bandNameInput does not exist_

PressAnyKeyPrompt: "`bandNameInput` does not exist in the database. Press any key to continue..."

**If N**

Return to main menu - addingAlbum: false

---

**If the input is 3:**

while deletingBand: true
userInput: PressAKeyPrompt - "Would you like to delete a band? Y/N: "

**If Y**

bandNameInput = Ask for string: "Which band do you want to delete?"

_If the `bandNameInput` exists_

confirmBandDelete = Ask for key: "Are you sure you want to delete `bandNameInput`? Y/N: "

_If Y_
confirmBandDeleteAgain = Ask for key: "Are you reeeeeeally sure you want to delete `bandNameInput` from the database? Y/N: "

    *If Y*
    context.SaveChanges
    PressAnyKeyPrompt: "We've deleted `bandNameInput` from our database. Press any key to continue..."
    deletingBand: false

    *If N*
    deletingBand: false

_If N_
deletingBand: false

_If the `bandNameInput` does not exist_
PressAnyKeyPrompt: The `bandNameInput` does not exist

**If N**
deletingBand: false

---

**If the input is 4**

while signingBand: true
userInput: PressAKeyprompt - "Would you like to sign or let go of a band? S - Sign | L - Let go | M - Main Menu "

**If S**

bandNameInput = Ask for string: "Which band do you want to sign?"

_If bandNameInput exists_

confirmBandSign = Ask for key: "Are you sure you want to sign `bandNameInput`?"

_If Y_

context.SaveChanges
PressAnyKeyPrompt: We've signed `bandNameInput`. Press any key to continue...
signingBand: false

_If N_

Go back to signingBand menu

_If bandNameInput does not exist_

PressAnyKeyPrompt: The band does not exist in the database. Press any key to continue...
Go back to signingBand menu

**If L**

bandNameInput = Ask for string: "Which band do you want to let go?"

_If bandNameInput exists_

confirmBandSign = Ask for key: "Are you reaaaally sure you want to let `bandNameInput` go?"

_If Y_
context.SaveChanges
PressAnyKeyPrompt: We've let `bandNameInput` go. Press any key to continue...
signingBand: false

_If N_

Go back to signingBand menu

_If bandNameInput does not exist_

PressAnyKeyPrompt: The band does not exist in the database. Press any key to continue...
Go back to signingBand menu

**If M**

signingBand: false

---

**If the input is 5**

PressAnyKeyPrompt: Press any key to see all the bands in the database...

PressAnyKeyPrompt: Press any key to continue...

---

**If the input is 6**

while viewingAlbums = true
bandNameInput = Ask for string: Which band's albums did you want to see? Type `Menu` to get back to the main menu.

**If bandNameInput Exists**
Write: Here are all of the albums by `bandNameInput`:

foreach album in albums...

PressAnyKeyPrompt: Press any key to continue...
viewingAlbums = false

**If bandNameInput does not Exist**
PressAnyKeyPrompt: `bandNameInput` does not exist in the database. Press any key to continue...

**If bandNameInput == Menu**
viewingAlbums = false

---

**If the input is 7**

Write: Here are all of the albums ordered by the release date.

foreach album in albums

PressAnyKeyPrompt: Press any key to continue...

---

**If the input is 8**

while signingBand: true
userInput: PressAKeyprompt - For all signed bands | U - For all unsigned bands | M - For the main menu

**If S**
Write: Here are all of the signed bands in the database.

foreach band in bands where IsSigned == true

PressAnyKeyPrompt: Press any key to continue...

**If U**
Write: Here are all of the signed bands in the database.

foreach band in bands where IsSigned == false

PressAnyKeyPrompt: Press any key to continue...

**If M**
signingBand: false

---

**If input is Q**

PressAnyKeyPrompt: See ya again real soon~♪

applicationOpen = false

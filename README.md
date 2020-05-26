# SketchPad
SketchPad
Cilj projekta je napraviti funkcionalnu aplikaciju za crtanje s omogućenim postavkama četkice, mogućnosti da slike čuva u fajlove i učitava   
iz fajlova.

Klasa Brush:
  Sadrži informacije bitne za postavke iscrtavanja na glavnom prozoru, odnosno veličinu četkice, boju i to da li je odabrana četkica ili   
  gumica.
  - BrushSize - Property tipa integer koji predstavlja veličinu četkice
  - CustomBrush - Property tipa SolidColorBrush koji predstavlja boju četkice
  - BrushSelected - Property tipa bool koji ima vrednost true ako je četkica selektovana, odnosno false ako je gumica selektovana

WindowOpen:
  Sastoji se od Textboxa u koji se unosi adresa slike koju korisnik želi da učita na cnsBackground glavnog windowa
  - "Button_Click" postavlja vrednost WindowOpen.DialogResult na true
  
WindowSave:
  Sastoji se iz 2 Textboxa - u jedan korisnik unosi željenu adresu na koju želi da sačuva sliku, a u drugi ime slike
  - "Button_Click" postavlja vrednost WindowSave.DialogResult na true

WindowBrush:
  Sastoji se iz 4 Slidera, koji nose informaciju o veličini i boji četkice, kao i cnsPreview elementa koji prikazuje trenutnu boju četkice
  - "Button_Click" postavlja vrednost WindowBrush.DialogResult na true

WindowMain:
  Sastoji se iz menija s raznim funkcionalnostima i canvasa na kome korisnik crta po želji.
    
  Meni:
    Sadrži dugmad s glavnim funkcionalnostima programa
    - Open_Click - Metoda koja otvara WindowOpen iz koga uzima adresu fajla iz kog će se učitati slika na canvas
    - Save_Click - Metoda koja pravi od canvasa RenderTargetBitmap koji koristi za kreiranje DrawingVisuala od kog pomoću PngEncodera čuva 
                   sliku na adresi koju dobija od WindowSave  
    - Undo_Click - Metoda koja briše poslednju promenu na cnsBackground, i pamti je u listama redoPotez i redoContent
    - Redo_Click - Metoda koja dodaje na cnsBackground poslednji sadržaj dodat u listu redoContent.
    - Delete_Click - Metoda koja brše ceo sadržaj cnsBackground-a, i dodaje ga u redoContent listu.
    - Eraser_Click - Postavlja vrednost brush.BrushSelected na false
    - Brush_Click - Ako je vrednost brush.BrushSelected jednaka false, postavlja je na true, a inače otvara WindowBrush
    
  CnsBackground:
    Sadrži evente za crtanje po svojoj površini.
    - MouseLeftButtonDown - Event koji čisti liste redoContent i redoPotezi i dobija trenutnu poziciju miša
    - MouseMove - Event koji iscrtava elipsu na prethodnoj poziciji miša i dobija novu trenutnu poziciju miša
    - MouseUp - Event koji završava potez i pamti vrednost u undoPotez, kako bi se "Undo_Click" eventom uklonio s cnsBackground-a
    

-- Text Editor Set containing 4 sequences of characters
data Texteditor = Texteditor ([Char],[Char],[Char],[Char]) deriving (Show)

--4 Sequences of Characters in the Text Editor:
-- l = Left of Cursor
-- h = Highlighted Characters
-- s = Right of Cursor
-- b = Clipboard/Buffer

--Creates instance of Text Editor
t :: Texteditor
t = Texteditor("The cat sat", " on the", " mat.", "NEW TEXT")

-- Functions:

--Initialising Text Editor
--Returns an empty Text Editor
new :: Texteditor -> Texteditor
new (Texteditor (l, h, s, b)) = (Texteditor ([],[],[],[]))

--Inputting Character
--Checks if there are less than 1024 characters in the Text Editor so that the limit is not exceeded
--If passed through, returns Text Editor with new character appended to left of cursor
inputChar :: Texteditor -> Char -> Texteditor
inputChar (Texteditor (l, h, s, b)) c
 | (length (l++h++s) < 1024) = (Texteditor (l++[c], [], s, b))
 
--Deleting Left Character/Backspace
--Checks if left of cursor is empty, so that it does not try to delete characters from an empty sequence
--Returns Text Editor with left character deleted and empty highlight
deleteCharLeft :: Texteditor -> Texteditor
deleteCharLeft (Texteditor (l, h, s, b))  
 | l /= [] = (Texteditor (init l, [], s, b))
 | otherwise = (Texteditor (l, [], s, b))

--Deleting Right Character/Delete
--Checks if right of cursor is empty, so that it does not try to delete characters from an empty sequence
--Returns Text Editor with right character deleted and empty highlight
deleteCharRight :: Texteditor -> Texteditor
deleteCharRight (Texteditor (l, h, s, b))  
 | s /= [] = (Texteditor (l, [], (tail s), b))
 | otherwise = (Texteditor (l, [], s, b))

--Moving Cursor Right
--Checks if right of cursor is empty, so that it does not try to move cursor when at the end of the line
--Returns Text Editor with cursor moved to right
cursorRight :: Texteditor -> Texteditor
cursorRight (Texteditor (l, h, s, b)) 
 | s /= [] = (Texteditor (((l++h)++[head s]), [],  tail s, b ))
 | otherwise = (Texteditor (l++h, [], s, b))

--Moving Cursor Left
--Checks if left of cursor is empty, so that it does not try to move cursor when at the start of the line
--Returns Text Editor with cursor moved to left
cursorLeft :: Texteditor -> Texteditor
cursorLeft (Texteditor (l, h, s, b))  
 | l /= [] = (Texteditor (init l, [], (head(reverse l)):(h ++ s), b))
 | otherwise = (Texteditor (l, [], h++s, b))

--Moving Cursor Word Right
--Boundary: Checks if right of cursor is empty, so that it does not try to move cursor when at the end of the line
--If it is empty, highlight is concantenated to left then, returns Text Editor with highlight and right of cursor empty
--If: Checks if the head of the right of the cursor is a ' ' character
--Then: Returns Text Editor with cursor moved to the right
--Else: Recalls cursorWordRight function with Text Editor with cursor moved to the right
cursorWordRight :: Texteditor -> Texteditor
cursorWordRight (Texteditor(l, h, s, b))
 | s == [] = (Texteditor (l ++ h, [], [], b))
 | (head s) == ' ' = (Texteditor (((l++h)++[head s]),[], tail(s), b))
 | otherwise = cursorWordRight(Texteditor (((l++h)++[head s]),[], tail(s), b))

--Moving Cursor Word Left
--Boundary: Checks if left of cursor is empty, so that it does not try to move cursor when at the start of the line
--If it is empty, highlight is concantenated to right then, returns Text Editor with highlight and left of cursor empty
--If: Checks if the head of the left of the cursor is a ' ' character
--Then: Returns Text Editor with cursor moved to the left
--Else: Recalls cursorWordLeft function with Text Editor with cursor moved to the left
cursorWordLeft :: Texteditor -> Texteditor
cursorWordLeft (Texteditor (l, h, s, b))
 | l == [] = (Texteditor ([], [], h ++ s, b))
 | (head (reverse l)) == ' ' = (Texteditor (l, [], s, b))
 | otherwise = cursorWordLeft (Texteditor (init l, [], (head (reverse l)) : (h ++ s), b))

--Move Cursor to Line Start
--Returns Text Editor with left of cursor, highlight and right of cursor concantenated together, in the right of the cursor
cursorLineStart :: Texteditor -> Texteditor
cursorLineStart (Texteditor (l, h, s, b)) = (Texteditor ([], [], l++h++s, b))

--Move Cursor to Line End
--Returns Text Editor with left of cursor, highlight and right of cursor concantenated together, in the left of the cursor
cursorLineEnd :: Texteditor -> Texteditor
cursorLineEnd (Texteditor (l, h, s, b)) = (Texteditor (l++h++s, [], [], b))

--Select Right Character
--Checks if right of cursor is empty so that it does not try to select a character from an empty sequence
--Returns Text Editor with the character to the right selected, in the highlight
selectCharRight :: Texteditor -> Texteditor
selectCharRight (Texteditor (l, h, s, b)) 
 | s /= []= (Texteditor (l, h ++ [head s], (tail s), b))
 | otherwise = (Texteditor (l, h, s, b))

--Select Left Character
--Checks if left of cursor is empty so that it does not try to select a character from an empty sequence
--Returns Text Editor with the character to the left selected, in the highlight
selectCharLeft :: Texteditor -> Texteditor
selectCharLeft (Texteditor (l, h, s, b))
 | l /= [] = (Texteditor (init l, (head (reverse l)) : h, s, b))
 | otherwise = (Texteditor (l, h, s, b))

--Select Right Word
--Boundary: Checks if right of cursor is empty, if true, returns Text Editor right of cursor empty
--If: Checks if the head of the right of the cursor is a ' ' character
--Then: Returns Text Editor with highlight concantenated with the head of the right of the cursor, in the highlight
--Else: Recalls selectWordRight function with Text Editor with highlight concantenated with the head of the right of the cursor, in the highlight
selectWordRight :: Texteditor -> Texteditor
selectWordRight (Texteditor (l, h, s, b))
 | s == [] = (Texteditor (l, h, [], b))
 | (head s) == ' ' = (Texteditor (l, h ++ [head s], (tail s), b))
 | otherwise = selectWordRight(Texteditor (l, h ++ [head s], (tail s), b))

--Select Left Word
--Boundary: Checks if left of cursor is empty, if true, returns Text Editor left of cursor empty
--If: Checks if the head of the left of the cursor is a ' ' character
--Then: Returns Text Editor with the last character of the left of the cursor appended to the front of highlight, in the highlight
--Else: Recalls selectWordRight function with Text Editor with the last character of the left of the cursor appended to the front of highlight, in the highlight
selectWordLeft :: Texteditor -> Texteditor
selectWordLeft (Texteditor (l, h, s, b))
 | l == [] = (Texteditor ([], h, s, b))
 | (head (reverse l)) == ' ' = (Texteditor (init l, (head (reverse l)) : h, s, b))
 | otherwise = selectWordLeft(Texteditor (init l, (head (reverse l)) : h, s, b))

--Select to Line Start
--Returns Text Editor with the left of cursor concantenated to the highlight, in the highlight
selectLineStart :: Texteditor -> Texteditor
selectLineStart (Texteditor (l, h, s, b)) = (Texteditor ([], l ++ h, s, b))

--Select to Line End
--Returns Text Editor with the highlight concantenated to the right of cursor, in the highlight
selectLineEnd :: Texteditor -> Texteditor
selectLineEnd (Texteditor (l, h, s, b)) = (Texteditor (l, h ++ s, [], b))

--Select All
--Returns Text Editor with left of cursor, highlight and right of cursor concantenated together, in the hightlight
selectAll :: Texteditor -> Texteditor
selectAll(Texteditor (l, h, s, b)) = (Texteditor ([], (l ++ h ++ s), [], b))
 
--Cut
--Checks if highlight is empty so that it does not try to cut a sequence of characters from an empty sequence
--Returns Text Editor with an empty sequence in the highlight and the highlight in the clipboard/buffer
cut :: Texteditor -> Texteditor
cut (Texteditor (l, h, s, b)) 
 | ((length h) > 0) = (Texteditor (l, [], s, h))
 | otherwise = (Texteditor (l, h, s, b))

--Copy
--Checks if highlight is empty so that it does not try to copy a sequence of characters from an empty sequence
--Returns Text Editor with the highlight in the clipboard/buffer
copy :: Texteditor -> Texteditor
copy (Texteditor (l, h, s, b)) 
 | ((length h) > 0) = (Texteditor (l, h, s, h))
 | otherwise = (Texteditor (l, h, s, b))

--Paste
--Checks if there are less than 1024 characters in the Text Editor so that the limit is not exceeded
--Returns Text Editor with the left of the cursor concantenated with the clipboard/buffer
paste :: Texteditor -> Texteditor
paste (Texteditor (l, h, s, b)) 
 | (length (l++b++s) < 1024) = (Texteditor (l++b, [], s, b))
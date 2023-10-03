# Zastita informacija

WindowsForms aplikacija sa temom upotreba razlicitih algoritma za **enkripciju** :lock: i **dekripciju** :unlock: podataka *(text/image)*. Projekat je napisan koriscenjem **.NET 7.0 framework-a**.

Implementirani algoritmi:
1. **A5/1** :white_check_mark:
2. **CFB** :white_check_mark:
3. **RSA** :white_check_mark:
4. **AES *(128B/192B/256B)*** :white_check_mark:
5. **SHA2** :white_check_mark:

## Priprema za pokretanje

Za pokretanje projekta neophodno je instalirati **.NET 7.0** sa linka: *https://dotnet.microsoft.com/en-us/download* i **VisualStudio 2022 IDE**.

## :checkered_flag: Pokretanje

Pokretanje se vrsi otvaranjem fajla: "*ZI_Projekat_17738.sln*" koriscenjem VisualStudio IDE-a.

Nakon pokretanja, dobijamo mogucnost odabira algoritma koji zelimo da koristimo za **enkripciju** :lock: i **dekripciju** :unlock: podataka.

Nakon odabira algoritma, za sve algoritme (*osim **SHA2***) dobijamo mogucnost enkripcije/dekripcije teksta :page_facing_up: sa kljucem :key: koji takodje unosimo sami, ili odabirom fajla sa ekstenzijom: **.txt**, a za pojedine algoritme (***RSA & AES***) imamo mogucnost da vrsimo enkripciju/dekripciju slika :camera: sa formatom: **.png**.

Ukoliko izaberemo **SHA2** algoritam, mozemo da procerimo da li 2 fajla imaju istu vrednost, odnosno da li im se poklapaju potpisi :memo:.

> :information_source: **AES** algoritam sam podesava da li ce se koristiti 128B, 192B ili 256B verzija na osnovu duzine kljuca :key: koji smo uneli.

> :information_source: **RSA** algoritam za enkriptovanje/dekriptovanje slika :camera: moze malo da potraje :stopwatch: u zavisnosti od velicine slike koju smo izabrali, nakon zavrsetka, dobijamo na formi prikaz kriptovanih/dekriptovanih podataka, kao i mogucnost za cuvanje rezultata. 
>
> :information_source: Nakon enkripcije slike, pa dekripcije, mozemo da upotrebimo **SHA2** da proverimo :microscope: da li algoritam funkcionise ispravno!


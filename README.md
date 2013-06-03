# Pinta Night Vision Effect

This is a simple effect, that will recolour your image to look like it's been taken with a night vision camera. Afterwards you can apply the Noise effect for an even better look!

##Notes

- It has lib copies of the current Pinta.Core and Pinta.Tools to build against, and they currently need manual updating. (Need to look into automatic updates here.)

- It builds a single dll that needs to be copied to Pinta's bin folder 
(when developing) or Pinta's install folder (installed Pinta). It is setup for automatic building and distribution via Pinta's addin server.

##Translations

Anyone wishing to contribute translations can do so by editing ```NightVisionAddin/.addin.xml``` and adding translated strings there, using the "nb" translation strings as examples.

##Bugs

All bugs should be reported to the issue tracker on this Github page, not to the main Pinta bug tracker.

##Roadmap

- Currently this has no GUI or configuration options,  which it really should have.
- It should also maybe automatically use some of the other effects for better results. (Like Noise & Soften.)

## License

As with the rest of Pinta, this is licensed under the MIT/X11 license.

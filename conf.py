# Configuration file for the Sphinx documentation builder.
#
# For the full list of built-in configuration values, see the documentation:
# https://www.sphinx-doc.org/en/master/usage/configuration.html

# -- Project information -----------------------------------------------------
# https://www.sphinx-doc.org/en/master/usage/configuration.html#project-information

project = 'OpenTabletDriver Plugin Documentation'
copyright = '2024, Gess1t (Mrcubix)'
author = 'Gess1t (Mrcubix)'
release = '0.5.3.3'

# -- General configuration ---------------------------------------------------
# https://www.sphinx-doc.org/en/master/usage/configuration.html#general-configuration

extensions = [
    "myst_parser",
    "sphinx_copybutton",
    "sphinx_tabs.tabs"
]

myst_enable_extensions = [
    "colon_fence",
    "attrs_block",
    "attrs_inline",
    "html_admonition"
]

templates_path = ['_templates']
exclude_patterns = ['_build', 'Thumbs.db', '.DS_Store', 'TODO.md', 'README.md']

# -- Options for HTML output -------------------------------------------------
# https://www.sphinx-doc.org/en/master/usage/configuration.html#options-for-html-output

html_theme = 'sphinx_rtd_theme'
html_static_path = ['_static']
html_css_files = [
    'css/override.css',
    'css/custom.css'
]
html_theme_options = {
    "collapse_navigation": False,
    "display_version": True,
}

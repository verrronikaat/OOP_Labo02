# -*- coding: utf-8 -*-
"""Конвертация RESX в ResourceDictionary XAML для ветки lab2-xaml."""
import pathlib
import xml.etree.ElementTree as ET
import html


def load_resx(path: pathlib.Path) -> dict[str, str]:
    tree = ET.parse(path)
    root = tree.getroot()
    out: dict[str, str] = {}
    for elem in root.iter():
        if elem.tag.endswith("data"):
            name = elem.attrib.get("name")
            if not name:
                continue
            v_el = None
            for child in elem:
                if child.tag.endswith("value"):
                    v_el = child
                    break
            text = (v_el.text if v_el is not None else "") or ""
            out[name] = text
    return out


def esc_xml(s: str) -> str:
    return (
        html.escape(s, quote=True)
        .replace("'", "&apos;")
    )


def write_xaml(path: pathlib.Path, data: dict[str, str]) -> None:
    lines = [
        '<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"',
        '                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"',
        '                    xmlns:sys="clr-namespace:System;assembly=System.Runtime">',
    ]
    for k in sorted(data.keys()):
        lines.append(f'  <sys:String x:Key="{k}">{esc_xml(data[k])}</sys:String>')
    lines.append("</ResourceDictionary>")
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text("\n".join(lines) + "\n", encoding="utf-8")


root = pathlib.Path(__file__).resolve().parents[1]
ru = load_resx(root / "src" / "OOP_Labo01" / "Properties" / "Resources.resx")
en = load_resx(root / "src" / "OOP_Labo01" / "Properties" / "Resources.en.resx")
write_xaml(root / "src" / "OOP_Labo01" / "Resources" / "UiStrings.ru.xaml", ru)
write_xaml(root / "src" / "OOP_Labo01" / "Resources" / "UiStrings.en.xaml", en)
print("ok", len(ru), len(en))

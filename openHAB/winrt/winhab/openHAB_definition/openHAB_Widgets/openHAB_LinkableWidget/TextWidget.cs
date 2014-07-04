﻿using JSON_Parser.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openhab.winrt.winhab.openHAB_definition.openhab_Interfaces.linkable;
using openhab.winrt.winhab.other;

namespace openhab.winrt.winhab.openHAB_definition.openHAB_Widgets.openHAB_LinkableWidget
{
    class TextWidget : AbstractWidget, ITextWidget
    {
        //  String labelState;

        public TextWidget(Widget widget)
        {
            this.widgetId = widget.widgetId;
            this.type = widget.type;
            this.label = widget.label;
            this.icon = widget.icon;
            this.widget = widget.widget;
            this.linkedPage = widget.linkedPage;
            this.item = widget.item;
            this._once = true;
            this.guiText = widget.guiText;
            this.guiValue = widget.guiValue;
            this.pathToIcon = widget.pathToIcon;
            // this.labelState = widget.label.Substring(2);
            base.widgetId = widget.widgetId;
            base.type = widget.type;
            base.label = widget.label;
            base.icon = widget.icon;
            base.widget = widget.widget;
            base.linkedPage = widget.linkedPage;
            base.item = widget.item;
            base._once = true;
        }
        public TextWidget(TextWidget widget)
        {
            this.widgetId = widget.widgetId;
            this.type = widget.type;
            this.label = widget.label;
            this.icon = widget.icon;
            this.widget = widget.widget;
            this.linkedPage = widget.linkedPage;
            this.item = widget.item;
            this._once = true;
            this.guiText = widget.guiText;
            this.guiValue = widget.guiValue;
            this.pathToIcon = widget.pathToIcon;
            // this.labelState = widget.label.Substring(2);
            base.widgetId = widget.widgetId;
            base.type = widget.type;
            base.label = widget.label;
            base.icon = widget.icon;
            base.widget = widget.widget;
            base.linkedPage = widget.linkedPage;
            base.item = widget.item;
            base._once = true;
        }
        private String _widgetId { get; set; }

        public String widgetId
        {
            get
            {
                return _widgetId;
            }
            set
            {
                _widgetId = value;
                NotifyPropertyChanged("widgetId");
            }
        }

        private String _type { get; set; }

        public String type { get { return _type; } set { _type = value; } }

        private String _label { get; set; }

        public String label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                NotifyPropertyChanged("label");
            }
        }

        private String _icon { get; set; }
        private Boolean _once = false;

        public String icon
        {
            get { return _icon; }
            set
            {
                if (_once != true)
                {
                    _icon = value;
                    _once = true;
                }
                else
                    _icon = value;
                AppProperties.setPath();
                pathToIcon = AppProperties.path + "\\" + value + ".png";
                NotifyPropertyChanged("icon");
            }
        }

        public LinkedList<Widget> widget { get; set; }

        public LinkedPage linkedPage { get; set; }

        private Item _item { get; set; }
        public Item item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                if (value != null)
                    guiValue = value.state;
                NotifyPropertyChanged("item");
            }
        }
        public string _guiText { get; set; }
        public string guiText
        {
            get
            {
                return _guiText;
            }
            set
            {
                _guiText = value;
                NotifyPropertyChanged("guiText");
            }
        }

        private string _guiValue { get; set; }
        public string guiValue
        {
            get
            {
                try
                {
                    String tmp = _guiValue;
                    if (tmp.Contains('.'))
                    {
                        tmp = tmp.Replace('.', ',');
                    }
                    Double number = Convert.ToDouble(tmp);
                    _guiValue = Convert.ToString(number);
                    _guiValue = _guiValue + " °C";
                }
                catch (Exception ex)
                {

                }
                return _guiValue;
            }
            set
            {
                _guiValue = value;
                NotifyPropertyChanged("guiValue");
            }
        }
        private string _pathToIcon
        {
            get;
            set;
        }

        public string pathToIcon
        {
            get
            {
                return _pathToIcon;
            }
            set
            {
                _pathToIcon = value;
                NotifyPropertyChanged("pathToIcon");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}

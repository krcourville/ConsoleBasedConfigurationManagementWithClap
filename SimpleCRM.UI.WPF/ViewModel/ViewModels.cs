using System;
using SimpleCRM.Model;
namespace SimpleCRM.UI.WPF.ViewModels {
	class ContactViewModel {
			#region Id Property
			public const string IdPropertyName="Id";
			

			private Int32 _Id;
			public Int32 Id {
				get {
					return _Id;
				}
				

				set {
					if( _Id == value) {
						return;
					}
					

					RaisePropertyChanging(IdPropertyName);
					_Id = value;
					RaisePropertyChanged(IdPropertyName);
				}
				

			}
			

			#endregion
			

			#region Name Property
			public const string NamePropertyName="Name";
			

			private Name _Name;
			public Name Name {
				get {
					return _Name;
				}
				

				set {
					if( _Name == value) {
						return;
					}
					

					RaisePropertyChanging(NamePropertyName);
					_Name = value;
					RaisePropertyChanged(NamePropertyName);
				}
				

			}
			

			#endregion
			

			#region HomePhone Property
			private ObservableCollection<String> _HomePhone;
			public ObservableCollection<String> HomePhone {
				get {
					return _HomePhone ?? (_HomePhone = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region BusinessPhone Property
			private ObservableCollection<String> _BusinessPhone;
			public ObservableCollection<String> BusinessPhone {
				get {
					return _BusinessPhone ?? (_BusinessPhone = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region MobilePhone Property
			private ObservableCollection<String> _MobilePhone;
			public ObservableCollection<String> MobilePhone {
				get {
					return _MobilePhone ?? (_MobilePhone = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region HomeAddress Property
			public const string HomeAddressPropertyName="HomeAddress";
			

			private Address _HomeAddress;
			public Address HomeAddress {
				get {
					return _HomeAddress;
				}
				

				set {
					if( _HomeAddress == value) {
						return;
					}
					

					RaisePropertyChanging(HomeAddressPropertyName);
					_HomeAddress = value;
					RaisePropertyChanged(HomeAddressPropertyName);
				}
				

			}
			

			#endregion
			

			#region BusinessAddress Property
			public const string BusinessAddressPropertyName="BusinessAddress";
			

			private Address _BusinessAddress;
			public Address BusinessAddress {
				get {
					return _BusinessAddress;
				}
				

				set {
					if( _BusinessAddress == value) {
						return;
					}
					

					RaisePropertyChanging(BusinessAddressPropertyName);
					_BusinessAddress = value;
					RaisePropertyChanged(BusinessAddressPropertyName);
				}
				

			}
			

			#endregion
			

			#region EmailAddress Property
			private ObservableCollection<String> _EmailAddress;
			public ObservableCollection<String> EmailAddress {
				get {
					return _EmailAddress ?? (_EmailAddress = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region Activities Property
			private ObservableCollection<ICollection`1> _Activities;
			public ObservableCollection<ICollection`1> Activities {
				get {
					return _Activities ?? (_Activities = new ObservableCollection<ICollection`1>());
				}
				

			}
			

			#endregion
			

	}
	

	class ActivityViewModel {
			#region Id Property
			public const string IdPropertyName="Id";
			

			private Int32 _Id;
			public Int32 Id {
				get {
					return _Id;
				}
				

				set {
					if( _Id == value) {
						return;
					}
					

					RaisePropertyChanging(IdPropertyName);
					_Id = value;
					RaisePropertyChanged(IdPropertyName);
				}
				

			}
			

			#endregion
			

			#region Subject Property
			private ObservableCollection<String> _Subject;
			public ObservableCollection<String> Subject {
				get {
					return _Subject ?? (_Subject = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region Body Property
			private ObservableCollection<String> _Body;
			public ObservableCollection<String> Body {
				get {
					return _Body ?? (_Body = new ObservableCollection<String>());
				}
				

			}
			

			#endregion
			

			#region Contact Property
			public const string ContactPropertyName="Contact";
			

			private Contact _Contact;
			public Contact Contact {
				get {
					return _Contact;
				}
				

				set {
					if( _Contact == value) {
						return;
					}
					

					RaisePropertyChanging(ContactPropertyName);
					_Contact = value;
					RaisePropertyChanged(ContactPropertyName);
				}
				

			}
			

			#endregion
			

			#region TimeCreated Property
			public const string TimeCreatedPropertyName="TimeCreated";
			

			private DateTime? _TimeCreated;
			public DateTime? TimeCreated {
				get {
					return _TimeCreated;
				}
				

				set {
					if( _TimeCreated == value) {
						return;
					}
					

					RaisePropertyChanging(TimeCreatedPropertyName);
					_TimeCreated = value;
					RaisePropertyChanged(TimeCreatedPropertyName);
				}
				

			}
			

			#endregion
			

			#region Contact_Id Property
			public const string Contact_IdPropertyName="Contact_Id";
			

			private Int32? _Contact_Id;
			public Int32? Contact_Id {
				get {
					return _Contact_Id;
				}
				

				set {
					if( _Contact_Id == value) {
						return;
					}
					

					RaisePropertyChanging(Contact_IdPropertyName);
					_Contact_Id = value;
					RaisePropertyChanged(Contact_IdPropertyName);
				}
				

			}
			

			#endregion
			

	}
	

}



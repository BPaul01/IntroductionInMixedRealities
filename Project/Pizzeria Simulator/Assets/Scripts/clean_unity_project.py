import os


def remove_files(folder_path):
    try:
        # Walk through the folder and its sub folders
        for root, dirs, files in os.walk(folder_path):
            for file_name in files:
                if file_name.endswith(".meta"):
                    file_path = os.path.join(root, file_name)
                    os.remove(file_path)
                    print(f"Removed: {file_path}")

        print("Files removed successfully.")
    except Exception as e:
        print(f"Error: {e}")


folder_path = r"C:\Users\bodal\Documents\IMR\IntroductionInMixedRealities\Project\Pizzeria Simulator\Assets\3D Objects"
remove_files(folder_path)

﻿/*
Copyright (c) 2018 S. Tarık Çetin

This project is licensed under the terms of the MIT license.
Refer to the LICENCE file in the root folder of the project.
*/

using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace QuickPlayTool
{
    public static class SceneLocateHelper
    {
        /// <summary>
        /// *.unity
        /// </summary>
        public static readonly string UnitySceneFilePattern = "*.unity";

        /// <summary>
        /// Returns all scene file paths under <see cref="Application.dataPath"/>
        /// </summary>
        /// <param name="relative">Make paths relative</param>
        public static IEnumerable<string> GetAllScenePaths(bool relative)
        {
            var absolute = Directory.GetFiles(Application.dataPath, UnitySceneFilePattern, SearchOption.AllDirectories);
            return relative ? absolute.Select(MakeRelativePath) : absolute;
        }

        /// <summary>
        /// Extracts te name or preserves the path, depending on <paramref name="showPath"/>
        /// </summary>
        public static string GetNameOrPath(string path, bool showPath)
        {
            return showPath ? path : GetFileName(path);
        }

        /// <summary>
        /// Returns relative version of <paramref name="absolutePath"/>
        /// </summary>
        public static string MakeRelativePath(string absolutePath)
        {
            var assetsPath = Application.dataPath;
            var assets = "Assets";
            return absolutePath.Substring(assetsPath.Length - assets.Length);
        }

        /// <summary>
        /// Extracts last element of <paramref name="path"/>
        /// </summary>
        public static string GetFileName(string path)
        {
            return path.Split('\\', '/').Last();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Installer.utils
{
    public class TextResources
    {
        private readonly Languages _language;

        public TextResources(Languages language)
        {
            _language = language;
        }

        public TextResources()
        {
            _language = Languages.English;
        }

        public string GetTranslatedMainMenuHeaderText()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return "Configuración de instalación";
                case Languages.French:
                    return "Configuration d'installation";
                case Languages.Italian:
                    return "Configurazione di installazione";
                case Languages.Portuguese:
                    return "Configuração de instalação";
                case Languages.English:
                    return "Installation Settings";
                case Languages.German:
                    return "Installations Einstellungen";
                case Languages.Russian:
                    return "Настройки установки";
                case Languages.Japanese:
                    return "インストール設定";
                case Languages.Hindi:
                    return "स्थापना सेटिंग्स";
                case Languages.Chinese:
                    return "安装设置";
                case Languages.Korean:
                    return "설치 설정";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public string[] GetTranslatedMainMenuCheckBoxTexts()
        {
            switch (_language)
            {
                case Languages.Spanish:
                    return new string[]
                    {
                    "Eliminar anuncios",
                    "Descargar sin conexión",
                    "Audio de alta calidad (320 kbit/s)",
                    "Organizar cola de reproducción",
                    "Sin restricción de almacenamiento"
                    };
                case Languages.French:
                    return new string[]
                    {
                    "Supprimer les annonces",
                    "Télécharger hors ligne",
                    "Audio de haute qualité (320 kbit/s)",
                    "Organiser la file de lecture",
                    "Aucune restriction de stockage"
                    };
                case Languages.Italian:
                    return new string[]
                    {
                    "Rimuovi annunci",
                    "Scarica offline",
                    "Audio di alta qualità (320 kbit/s)",
                    "Organizza coda di riproduzione",
                    "Nessuna restrizione di archiviazione"
                    };
                case Languages.Portuguese:
                    return new string[]
                    {
                    "Remover anúncios",
                    "Baixar offline",
                    "Áudio de alta qualidade (320 kbit/s)",
                    "Organizar fila de reprodução",
                    "Sem restrição de armazenamento"
                    };
                case Languages.English:
                    return new string[]
                    {
                    "Remove ads",
                    "Download offline",
                    "High quality audio (320 kbit/s)",
                    "Organize playback queue",
                    "No storage restriction"
                    };
                case Languages.German:
                    return new string[]
                    {
                    "Werbung entfernen",
                    "Offline herunterladen",
                    "Hochwertiges Audio (320 kbit/s)",
                    "Wiedergabewarteschlange organisieren",
                    "Keine Speicherbegrenzung"
                    };
                case Languages.Russian:
                    return new string[]
                    {
                    "Удалить рекламу",
                    "Загрузить офлайн",
                    "Высококачественное аудио (320 кбит/с)",
                    "Организовать очередь воспроизведения",
                    "Без ограничения хранения"
                    };
                case Languages.Japanese:
                    return new string[]
                    {
                    "広告を削除する",
                    "オフラインでダウンロード",
                    "高品質オーディオ（320 kbit/s）",
                    "再生キューを整理する",
                    "ストレージ制限なし"
                    };
                case Languages.Hindi:
                    return new string[]
                    {
                    "विज्ञापन हटाएं",
                    "ऑफ़लाइन डाउनलोड करें",
                    "उच्च गुणवत्ता ऑडियो (320 किलोबिट/सेकंड)",
                    "प्लेबैक कतार संगठित करें",
                    "कोई स्टोरेज सीमा नहीं"
                    };
                case Languages.Chinese:
                    return new string[]
                    {
                    "删除广告",
                    "离线下载",
                    "高质量音频（320 kbit/s）",
                    "组织播放队列",
                    "无存储限制"
                    };
                case Languages.Korean:
                    return new string[]
                    {
                    "광고 제거",
                    "오프라인 다운로드",
                    "고음질 오디오 (320 kbit/s)",
                    "재생 큐 정리",
                    "저장 공간 제한 없음"
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

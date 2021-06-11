using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class PageGroup : MonoBehaviour
    {
        [SerializeField] private List<Page> pages;
        [SerializeField] private GameObject pageBlock;
        [SerializeField] private ReturnerProcessor returnerProcessor;
        [SerializeField] private ReturnPage returnPage;
        [SerializeField] private NextSelectedButton firstPageButton;
        public List<Page> Pages { get => pages; set => pages = value; }
        private Page selectedPage;
        public Page SelectedPage {get => selectedPage; set => selectedPage = value;}

        public void SetSelectedPage(int index)
        {
            if(selectedPage != null)
                ClearPages();
            
            selectedPage = pages[index];
            selectedPage.pageObj.SetActive(true);

            OnPageUpdate();

            StartCoroutine(SkipFrame(() =>
            {
                firstPageButton.SetButton(selectedPage.firstNavigatableElement);
                firstPageButton.Connect();
            }));
            
        }

        public void ClearPages()
        {
            for (int i = 0; i < pages.Count; i++)
            {
                var page = pages[i];
                page.pageObj.SetActive(false);
            }
            selectedPage = null;
            OnPageUpdate();
        }
        
        public void OnPageUpdate()
        {
            if(pageBlock == null)
                return;
            
            pageBlock.SetActive(selectedPage == null);

            if(selectedPage != null)
                returnerProcessor?.Subscribe(returnPage);
            else
                returnerProcessor?.Pop();
        }

        private void OnDisable()
        {
            ClearPages();
        }

        private IEnumerator SkipFrame(Action callback)
        {
            yield return null;

            callback?.Invoke();
        }
    }

    [Serializable]
    public class Page
    {
        public GameObject pageObj;
        public GameObject firstNavigatableElement;
    }
}

package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;


@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchResult extends AbstractServiceResult {

    /**
     * 契約情報リスト変数
     */
    private List<ContractSearchVO> _cntrctList = null;

    /**
     * 契約情報リストを設定します
     * @param val 契約情報リスト
     */
    public void setCntrctList(List<ContractSearchVO> val) {
        _cntrctList = val;
    }

    /**
     * 契約情報リストを取得します
     * @return 契約情報リスト
     */
    public List<ContractSearchVO> getCntrctList() {
        return _cntrctList;
    }
}

package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 経理組織展開テーブル表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/02 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMEU07SIKKRSPRDDispResult extends AbstractServiceResult
{
    /** 経理組織展開テーブル検索データVO */
    private FindMasterMaintenanceMEU07SIKKRSPRDVO _MEU07SIKKRSPRDVO = null;

    /**
     * 経理組織展開テーブル検索データVOを設定します
     * @param vo セットする _MEU07SIKKRSPRDVO
     */
    public void setMEU07SIKKRSPRDVO(FindMasterMaintenanceMEU07SIKKRSPRDVO vo)
    {
        _MEU07SIKKRSPRDVO = vo;
    }

    /**
     * 経理組織展開テーブル検索データVOを取得します
     * @return _MEU07SIKKRSPRDVO
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMEU07SIKKRSPRDVO()
    {
        return _MEU07SIKKRSPRDVO;
    }

}

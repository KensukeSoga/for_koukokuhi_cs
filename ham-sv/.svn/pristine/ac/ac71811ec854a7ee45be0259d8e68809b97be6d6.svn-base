package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 設定局表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceEstablishmentOfficeDispResult extends AbstractServiceResult
{
    /** 設定局検索データVO */
    private FindMbj29SetteiKykVO _establishmentOfficeVO = null;

    /**
     * 設定局検索データVOを設定します
     * @param vo セットする _establishmentOfficeVO
     */
    public void setEstablishmentOfficeVO(FindMbj29SetteiKykVO vo)
    {
        _establishmentOfficeVO = vo;
    }

    /**
     * 設定局検索データVOを取得します
     * @return _establishmentOfficeVO
     */
    public FindMbj29SetteiKykVO getEstablishmentOfficeVO()
    {
        return _establishmentOfficeVO;
    }

}

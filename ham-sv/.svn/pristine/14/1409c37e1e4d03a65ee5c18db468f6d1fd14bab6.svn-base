package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * インフォメーション表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInformationDispResult extends AbstractServiceResult
{
    /** インフォメーション検索データVO */
    private FindMbj31InformationVO _informationVO = null;

    /**
     * インフォメーション検索データVOを設定します
     * @param vo セットする _informationVO
     */
    public void setInformationVO(FindMbj31InformationVO vo)
    {
        _informationVO = vo;
    }

    /**
     * インフォメーション検索データVOを取得します
     * @return _informationVO
     */
    public FindMbj31InformationVO getInformationVO()
    {
        return _informationVO;
    }

}

package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 新聞マスタ表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/17 森)<BR>
 * </P>
 * @author 森
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceNewspaperDispResult extends AbstractServiceResult
{
    /** 新聞マスタ検索データVO */
    private FindMbj47NewspaperVO _newspaperVO = null;

    /** 新雑媒体マスタ検索データVO */
    private FindMasterMaintenanceMEU20MSMZBTVO _mEU20MSMZBTVO = null;

    /** 依頼先検索データVO */
    private FindMasterMaintenanceFindContactRequestVO _findContactRequestVO = null;

    /**
     * 新聞マスタ検索データVOを設定します
     * @param vo セットする _newspaperVO
     */
    public void setNewspaperVO(FindMbj47NewspaperVO vo)
    {
        _newspaperVO = vo;
    }

    /**
     * 新聞マスタ検索データVOを取得します
     * @return _newspaperVO
     */
    public FindMbj47NewspaperVO getNewspaperVO()
    {
        return _newspaperVO;
    }

    /**
     * 新雑媒体マスタ検索データVOを設定します
     * @param vo セットする _mEU20MSMZBTVO
     */
    public void setMEU20MSMZBTVO(FindMasterMaintenanceMEU20MSMZBTVO vo)
    {
        _mEU20MSMZBTVO = vo;
    }

    /**
     * 新雑媒体マスタ検索データVOを取得します
     * @return _mEU20MSMZBTVO
     */
    public FindMasterMaintenanceMEU20MSMZBTVO getMEU20MSMZBTVO()
    {
        return _mEU20MSMZBTVO;
    }

    /**
     * 依頼先検索データVOを設定します
     * @param vo セットする _findContactRequestVO
     */
    public void setFindContactRequestVO(FindMasterMaintenanceFindContactRequestVO vo)
    {
        _findContactRequestVO = vo;
    }

    /**
     * 依頼先検索データVOを取得します
     * @return _findContactRequestVO
     */
    public FindMasterMaintenanceFindContactRequestVO getFindContactRequestVO()
    {
        return _findContactRequestVO;
    }

}

package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * 車種担当(素材)表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserSozaiDispResult extends AbstractServiceResult
{
    /** 車種担当(素材)スプレッド検索データVO */
    private FindMasterMaintenanceCarUserSozaiSpreadVO _carUserSozaiSpreadVO = null;
    /** 車種検索データVO */
    private FindMbj05CarVO _carVo = null;
    /** セキュリティグループユーザー(HC/HM)検索データVO */
    private FindMasterMaintenanceHCHMSecGrpUserSpreadVO _HCHMSecGrpUserSpreadVO = null;


    /**
     * 車種担当(素材)スプレッド検索データVOを設定します
     * @param vo セットする _carUserSozaiSpreadVO
     */
    public void setCarUserSozaiSpreadVO(FindMasterMaintenanceCarUserSozaiSpreadVO vo)
    {
        _carUserSozaiSpreadVO = vo;
    }

    /**
     * 車種担当(素材)スプレッド検索データVOを取得します
     * @return _carUserSozaiSpreadVO
     */
    public FindMasterMaintenanceCarUserSozaiSpreadVO getCarUserSozaiSpreadVO()
    {
        return _carUserSozaiSpreadVO;
    }

    /**
     * 車種検索データVOを設定します
     * @param vo セットする _carVO
     */
    public void setCarVO(FindMbj05CarVO vo) {
        _carVo = vo;
    }

    /**
     * 車種検索データVOを取得します
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO() {
        return _carVo;
    }
    /**
     * セキュリティグループユーザー(HC/HM)スプレッド検索データVOを設定します
     * @param vo セットする _HCHMSecGrpUserSpreadVO
     */
    public void setHCHMSecGrpUserSpreadVO(FindMasterMaintenanceHCHMSecGrpUserSpreadVO vo)
    {
        _HCHMSecGrpUserSpreadVO = vo;
    }

    /**
     * セキュリティグループユーザー(HC/HM)スプレッド検索データVOを取得します
     * @return _carUserSozaiSpreadVO
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO getHCHMSecGrpUserSpreadVO()
    {
        return _HCHMSecGrpUserSpreadVO;
    }

}

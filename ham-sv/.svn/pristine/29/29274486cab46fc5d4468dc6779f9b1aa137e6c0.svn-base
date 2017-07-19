package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM担当者表示情報Result
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHMUserDispResult extends AbstractServiceResult
{
    /** HM担当者検索データVO */
    private FindMbj48HmUserVO _hmUserVo = null;
    /** コードマスタ検索データVO */
    private FindMbj12CodeVO _codeVo = null;

    /**
     * HM担当者検索データVOを設定する
     * @param vo FindMbj48HmUserVO HM担当者検索データVO
     */
    public void setHMUserVO(FindMbj48HmUserVO vo) {
        _hmUserVo = vo;
    }

    /**
     * HM担当者検索データVOを取得する
     * @return FindMbj48HmUserVO HM担当者検索データVO
     */
    public FindMbj48HmUserVO getHMUserVO() {
        return _hmUserVo;
    }

    /**
     * コードマスタ検索データVOを設定する
     * @param vo FindMbj12CodeVO コードマスタ検索データVO
     */
    public void setCodeVO(FindMbj12CodeVO vo) {
        _codeVo = vo;
    }

    /**
     * コードマスタ検索データVO
     * @return FindMbj12CodeVO コードマスタ検索データVO
     */
    public FindMbj12CodeVO getCodeVO() {
        return _codeVo;
    }

}

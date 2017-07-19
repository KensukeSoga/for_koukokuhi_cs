package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Tbj42SozaiKanriListCmnVO;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;

/**
 * <P>
 * 素材一覧　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * ・HDX対応(2016/02/23 HLC K.Soga)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterMaterialListVO implements Serializable {

    private static final long serialVersionUID = 1L;

    /**
     * 検索条件
     */
    private MaterialListCondition _materialListCondition = null;

    /**
     * 素材登録用登録日
     */
    private Date _materialDate = null;

    /**
     * 素材一覧登録用VOリスト
     */
    private List<RegisterMaterialListUpdateVO> _regList = null;

    /**
     * 素材一覧更新用VOリスト
     */
    private List<RegisterMaterialListUpdateVO> _updList = null;

    /**
     * 素材一覧削除用VOリスト
     */
    private List<RegisterMaterialListUpdateVO> _delList = null;

    /**
     * 車種変換マスタVO
     */
    private Mbj38CarConvertVO _carConvert = null;

    /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材一覧(共通)登録用VO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42RegList = null;

    /**
     * 素材一覧(共通)更新用VO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42UpdList = null;

    /**
     * 素材一覧(共通)削除用VO
     */
    private List<Tbj42SozaiKanriListCmnVO> _tbj42DelList = null;

    /**
     * 素材一覧(共通OA期間)登録用VO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43RegList = null;

    /**
     * 素材一覧(共通OA期間)更新用VO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43UpdList = null;

    /**
     * 素材一覧(共通OA期間)削除用VO
     */
    private List<Tbj43SozaiKanriListCmnOAVO> _tbj43DelList = null;
    /** 2016/02/23 HDX対応 HLC K.Soga ADD End */

    /**
     * 素材登録用登録日を設定します
     * @param dt
     */
    public void setMaterialDate(Date dt) {
        _materialDate = dt;
    }

    /**
     * 素材登録用登録日を取得します
     * @param dt
     */
    public Date getMaterialDate() {
        return _materialDate;
    }

    /**
     * 検索条件を設定します
     * @param cond
     */
    public void setMaterialListCondition(MaterialListCondition cond) {
        _materialListCondition = cond;
    }

    /**
     * 検索条件を取得します
     * @return
     */
    public MaterialListCondition getMaterialListCondition() {
        return _materialListCondition;
    }

    /**
     * 素材一覧登録用VOリストを設定します
     * @param vo
     */
    public void setRegVOList(List<RegisterMaterialListUpdateVO> vo) {
        _regList = vo;
    }

    /**
     * 素材一覧登録用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getRegVOList() {
        return _regList;
    }

    /**
     * 素材一覧更新用VOリストを設定します
     * @param vo
     */
    public void setUpdVOList(List<RegisterMaterialListUpdateVO> vo) {
        _updList = vo;
    }

    /**
     * 素材一覧更新用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getUpdVOList() {
        return _updList;
    }

    /**
     * 素材一覧削除用VOリストを設定します
     * @param vo
     */
    public void setDelVOList(List<RegisterMaterialListUpdateVO> vo) {
        _delList = vo;
    }

    /**
     * 素材一覧削除用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialListUpdateVO> getDelVOList() {
        return _delList;
    }

    /**
     * 車種変換マスタVOを設定します
     * @param vo
     */
    public void setCarConvert(Mbj38CarConvertVO vo) {
        _carConvert = vo;
    }

    /**
     * 車種変換マスタVOを取得します
     * @return
     */
    public Mbj38CarConvertVO getCarConvert() {
        return _carConvert;
    }

    /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
    /**
     * 素材一覧(共通)登録用VOを取得する
     * @return List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)登録用VO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42RegVOList() {
        return _tbj42RegList;
    }

    /**
     * 素材一覧(共通)登録用VOを設定する
     * @param vo List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)登録用VO
     */
    public void setTbj42RegVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42RegList = vo;
    }

    /**
     * 素材一覧(共通)更新用VOを取得する
     * @return List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)更新用VO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42UpdVOList() {
        return _tbj42UpdList;
    }

    /**
     * 素材一覧(共通)更新用VOを設定する
     * @param vo List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)更新用VO
     */
    public void setTbj42UpdVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42UpdList = vo;
    }

    /**
     * 素材一覧(共通)削除用VOを取得する
     * @return List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)削除用VO
     */
    public List<Tbj42SozaiKanriListCmnVO> getTbj42DelVOList() {
        return _tbj42DelList;
    }

    /**
     * 素材一覧(共通)削除用VOを設定する
     * @param vo List<Tbj42SozaiKanriListCmnVO> 素材一覧(共通)削除用VO
     */
    public void setTbj42DelVOList(List<Tbj42SozaiKanriListCmnVO> vo) {
        _tbj42DelList = vo;
    }

    /**
     * 素材一覧(共通OA期間)登録用VOを取得する
     * @return List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)登録用VO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43RegVOList() {
        return _tbj43RegList;
    }

    /**
     * 素材一覧(共通OA期間)登録用VOを設定する
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)登録用VO
     */
    public void setTbj43RegVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43RegList = vo;
    }

    /**
     * 素材一覧(共通OA期間)更新用VOを取得する
     * @return List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)更新用VO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43UpdVOList() {
        return _tbj43UpdList;
    }

    /**
     * 素材一覧(共通OA期間)更新用VOを設定する
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)更新用VO
     */
    public void setTbj43UpdVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43UpdList = vo;
    }

    /**
 * 素材一覧(共通OA期間)削除用VOを取得する
     * @return List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)削除用VO
     */
    public List<Tbj43SozaiKanriListCmnOAVO> getTbj43DelVOList() {
        return _tbj43DelList;
    }

    /**
     * 素材一覧(共通OA期間)削除用VOを設定する
     * @param vo List<Tbj43SozaiKanriListCmnOAVO> 素材一覧(共通OA期間)削除用VO
     */
    public void setTbj43DelVOList(List<Tbj43SozaiKanriListCmnOAVO> vo) {
        _tbj43DelList = vo;
    }
    /** 2016/02/23 HDX対応 HLC K.Soga ADD End */
}

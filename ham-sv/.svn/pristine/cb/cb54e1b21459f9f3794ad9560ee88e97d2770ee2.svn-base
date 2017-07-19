package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentVO;

/**
 * <P>
 * 素材登録　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * ・JASRAC対応(2015/11/10 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterMaterialVO implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 検索条件
     */
    private MaterialRegisterCondition _materialRegisterCondition = null;

    /**
     * 本素材登録用VOリスト
     */
    private List<RegisterMaterialContentVO> _regList = null;

    /**
     * 本素材更新用VOリスト
     */
    private List<RegisterMaterialContentVO> _updList = null;

    /**
     * 本素材削除用VOリスト
     */
    private List<RegisterMaterialContentVO> _delList = null;

    /**
     * 契約情報更新リスト
     */
    private List<Tbj16ContractInfoUpdateVO> _updCntrctList = null;

    /**
     * 契約情報登録リスト
     */
    private List<Tbj16ContractInfoUpdateVO> _regCntrctList = null;

    /**
     * 契約情報削除リスト
     */
    private List<Tbj16ContractInfoUpdateVO> _delCntrctList = null;

    /** 2015/11/10 JASRAC対応 HLC K.Soga ADD Start */
    /** 仮素材登録用VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36InsVo = null;

    /** 仮素材更新用VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36UpdVo = null;

    /** 仮素材削除用VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36DelVo = null;

    /** 契約仮素材紐付け登録用VO */
    private List<Tbj40TempSozaiContentVO> _tbj40InsVo = null;
    /** 2015/11/10 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 検索条件を設定します
     * @param cond
     */
    public void setMaterialRegisterCondition(MaterialRegisterCondition cond) {
        _materialRegisterCondition = cond;
    }

    /**
     * 検索条件を取得します
     * @return
     */
    public MaterialRegisterCondition getMaterialRegisterCondition() {
        return _materialRegisterCondition;
    }

    /**
     * 本素材登録用VOリストを設定します
     * @param vo
     */
    public void setRegVOList(List<RegisterMaterialContentVO> vo) {
        _regList = vo;
    }

    /**
     * 本素材登録用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialContentVO> getRegVOList() {
        return _regList;
    }

    /**
     * 本素材更新用VOリストを設定します
     * @param vo
     */
    public void setUpdVOList(List<RegisterMaterialContentVO> vo) {
        _updList = vo;
    }

    /**
     * 本素材更新用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialContentVO> getUpdVOList() {
        return _updList;
    }

    /**
     * 本素材削除用VOリストを設定します
     * @param vo
     */
    public void setDelVOList(List<RegisterMaterialContentVO> vo) {
        _delList = vo;
    }

    /**
     * 本素材削除用VOリストを取得します
     * @return
     */
    public List<RegisterMaterialContentVO> getDelVOList() {
        return _delList;
    }

    /**
     * 契約情報更新リストを設定します
     * @param vo
     */
    public void setUpdCntrctList(List<Tbj16ContractInfoUpdateVO> vo) {
        _updCntrctList = vo;
    }

    /**
     * 契約情報更新リストを取得します
     * @return
     */
    public List<Tbj16ContractInfoUpdateVO> getUpdCntrctList() {
        return _updCntrctList;
    }

    /**
     * 契約情報登録リストを設定します
     * @param vo
     */
    public void setRegCntrctList(List<Tbj16ContractInfoUpdateVO> vo) {
        _regCntrctList = vo;
    }

    /**
     * 契約情報登録リストを取得します
     * @return
     */
    public List<Tbj16ContractInfoUpdateVO> getRegCntrctList() {
        return _regCntrctList;
    }

    /**
     * 契約情報削除リストを設定します
     * @param vo
     */
    public void setDelCntrctList(List<Tbj16ContractInfoUpdateVO> vo) {
        _delCntrctList = vo;
    }

    /**
     * 契約情報削除リストを取得します
     * @return
     */
    public List<Tbj16ContractInfoUpdateVO> getDelCntrctList() {
        return _delCntrctList;
    }

    /** 2015/11/10 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮素材登録用VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材登録用VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36InsVo() {
        return _tbj36InsVo;
    }

    /**
     * 仮素材登録用VOを設定する
     * @param vo List<Tbj36TempSozaiKanriDataVO> 仮素材登録用VO
     */
    public void setTbj36InsVo(List<Tbj36TempSozaiKanriDataVO> vo) {
        _tbj36InsVo = vo;
    }

    /**
     * 仮素材更新用VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材更新用VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36UpdVo() {
        return _tbj36UpdVo;
    }

    /**
     * 仮素材更新用VOを設定する
     * @param vo List<Tbj36TempSozaiKanriDataVO> 仮素材更新用VO
     */
    public void setTbj36UpdVo(List<Tbj36TempSozaiKanriDataVO> vo) {
        _tbj36UpdVo = vo;
    }

    /**
     * 仮素材削除用VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材更新用VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36DelVo() {
        return _tbj36DelVo;
    }

    /**
     * 仮素材削除用VOを設定する
     * @param vo List<Tbj36TempSozaiKanriDataVO> 仮素材更新用VO
     */
    public void setTbj36DelVo(List<Tbj36TempSozaiKanriDataVO> vo) {
        _tbj36DelVo = vo;
    }

    /**
     * 契約仮素材登録用VOを取得する
     * @return List<Tbj40TempSozaiContentVO> 契約仮素材登録用VO
     */
    public List<Tbj40TempSozaiContentVO> getTbj40InsVo() {
        return _tbj40InsVo;
    }

    /**
     * 契約仮素材登録用VOを設定する
     * @param vo List<Tbj40TempSozaiContentVO> 契約仮素材登録用VO
     */
    public void setTbj40InsVo(List<Tbj40TempSozaiContentVO> vo) {
        _tbj40InsVo = vo;
    }
    /** 2015/11/10 JASRAC対応 HLC K.Soga ADD End */
}
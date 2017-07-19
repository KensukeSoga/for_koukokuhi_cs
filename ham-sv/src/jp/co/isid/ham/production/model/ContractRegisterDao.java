package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj24LogContractInfoVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj19Jasrac;
import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 * <P>
 * �f�ޓo�^�e�[�u���擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 JSE A.Naito)<BR>
 * �EJASRAC�Ή�(2015/11/27 HLC S.Fujimoto)<BR>
 * �EHDX�Ή�(2016/02/24 HLC K.Oki)<BR>
 * </P>
 *
 * @author
 */
public class ContractRegisterDao extends AbstractRdbDao {

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum SelSqlMode {
        CONTRACT,
        CONTENT,
        TALENT,
        MUSIC,
        CountC,
        CountJ,
        TimeStamp,
        CmCd,
        ContractInfo,
        CTRTNO,
        History,
        SearchM,
        Category,
        Second,
        Syatan,
    };
    private SelSqlMode _SelSqlMode = null;

    /** getSelectSQL�Ŕ��s����SQL�̃��[�h() */
    private enum ExecSqlMode {
        DeleteC,
        DeleteJ,
        UpdateC,
        UpdateContent,
        InsertHistory,
        UpdateKLIMIT,
    };
    private ExecSqlMode _ExecSqlMode = null;

    /** �ėp�}�X�^�������� */
    private ContractDeleteCondition _cond2;
    /** �ėp�}�X�^�������� */
    private GetContractInfoListCondition _cond4;
    /** �ėp�}�X�^�������� */
    private Tbj16ContractInfoUpdateVO _vo;
    /** �ėp�}�X�^�������� */
    private Tbj18SozaiKanriDataUpdateVO _vo2;
    /** �R�[�h��ʁF�f�� */
    private String CODETYPE_CONTRACTINFO = "16";
    /** �폜�t���O�F�폜(D) */
    private String DeleteYes = "D";
    /** �폜�t���O�F( ) */
    private String DeleteNo = " ";

    /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto DEL Start */
    //    /** �_����(�^�����g) */
    //    private String CTRTKBN_TALENT = "1";
    //    /** �_����(�i���[�^�[) */
    //    private String CTRTKBN_NARRATOR = "3";
    //    /** �_����(�y��) */
    //    private String CTRTKBN_MUSIC = "4";
    //    /** �_����(���̑�) */
    //    private String CTRTKBN_SONOTA = "5";
    /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto DEL End */

    /** �������� */
    private FindLogContractInfoCondition _condLogContractInfo = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public ContractRegisterDao() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        //�g�p�f�ޕ\���p�f�[�^(�^�����g�E�i���[�^�[)�̎擾SQL
        if (_SelSqlMode.equals(SelSqlMode.TALENT)) {

            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD Start */
            //            sql.append(" SELECT ");
            //            sql.append("   " + Tbj17Content.CTRTKBN + " "); //�_����
            //            sql.append("  ," + Tbj17Content.CTRTNO + " "); //�_��R�[�h
            //            sql.append("  ," + Tbj18SozaiKanriData.NOKBN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.STATUS + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.NOHIN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATETO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.MLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.KLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEPRT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDID + " ");
            //            sql.append(" FROM ");
            //            sql.append("  " + Tbj17Content.TBNAME + " ");
            //            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");
            //            sql.append(" WHERE ");
            //            sql.append("  " + Tbj17Content.CMCD + " ");
            //            sql.append(" = " + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
            //            sql.append(" <> " + CTRTKBN_MUSIC + " "); //4�F�y��
            //            sql.append(" AND " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I') ");
            //            sql.append(" ORDER BY ");
            //            sql.append("  " + Tbj17Content.CMCD + " "); //10��CM�R�[�h
            //            sql.append(" ," + Tbj17Content.CTRTKBN + " "); //�_����
            //            sql.append(" ," + Tbj17Content.CTRTNO + " "); //�_��R�[�h

            //�{�f��
            sql.append(" SELECT");
            sql.append(" " + Tbj17Content.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + FindUseMaterialVO.TEMPFLG); //�{�f��

            sql.append(" FROM");
            sql.append(" " + Tbj17Content.TBNAME + ",");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " AND");
            sql.append(" " + Tbj17Content.CTRTKBN + " <> " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I')");

            sql.append(" UNION ALL");

            //���f��
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN+ " ,");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");    //���f��

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + Tbj40TempSozaiContent.TEMPCMCD + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " <> " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " NOT IN ('D', 'I')");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO);
            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD End */
        }

        //�g�p�f�ޕ\���p�f�[�^(�y��)�̎擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.MUSIC)) {

            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD Start */
            //            sql.append(" SELECT ");
            //            sql.append("   " + Tbj17Content.CTRTKBN + " "); //�_����
            //            sql.append("  ," + Tbj17Content.CTRTNO + " "); //�_��R�[�h
            //            sql.append("  ," + Tbj18SozaiKanriData.NOKBN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.STATUS + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.NOHIN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATETO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.MLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.KLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEPRT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDID + " ");
            //            sql.append(" FROM ");
            //            sql.append("  " + Tbj17Content.TBNAME + " ");
            //            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");
            //            sql.append(" WHERE ");
            //            sql.append("  " + Tbj17Content.CMCD + " ");
            //            sql.append(" = " + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
            //            sql.append(" = " + CTRTKBN_MUSIC + " "); //4�F�y��
            //            sql.append(" AND " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I') ");
            //            sql.append(" ORDER BY ");
            //            sql.append("  " + Tbj17Content.CMCD + " "); //10��CM�R�[�h
            //            sql.append(" ," + Tbj17Content.CTRTKBN + " "); //�_����
            //            sql.append(" ," + Tbj17Content.CTRTNO + " "); //�_��R�[�h

            //�{�f��
            sql.append(" SELECT");
            sql.append(" " + Tbj17Content.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + FindUseMaterialVO.TEMPFLG);

            sql.append(" FROM");
            sql.append(" " + Tbj17Content.TBNAME + ",");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj17Content.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + " NOT IN ( '" + HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE + "', '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' ) AND");
            sql.append(" " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD);

            sql.append(" UNION ALL");

            //���f��
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " NOT IN ( '" + HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE + "', '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' ) AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD);

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO);
            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD End */
        }

        //�R���e���c�f�[�^�̃J�E���g�̎擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.CountC)) {

            sql.append(" SELECT ");
            sql.append("  " + "COUNT(*) COUNT" + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + _cond2.getStrCtrtKbn() + " ");
            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + _cond2.getStrCtrtNo() + " ");
        }

        //JASRAC�f�[�^�̃J�E���g�̎擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.CountJ)) {

            sql.append(" SELECT ");
            sql.append("  " + "COUNT(*) COUNT" + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj19Jasrac.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj19Jasrac.CTRTNO + " ");
            sql.append(" = " + _cond2.getStrCtrtNo() + " ");
            sql.append(" AND " + Tbj19Jasrac.DELFLG + " ");
            sql.append(" = '" + DeleteNo + "' ");
        }

        //TIMESTAMP���ڂ̎擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.TimeStamp)) {

            sql.append(" SELECT ");
            sql.append("   " + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" FROM ");
            sql.append("   " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("   " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append("   = " + _cond4.getStrCtrtKbn() + " ");
            sql.append("  AND ");
            sql.append("   " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append("   = " + _cond4.getStrCtrtNo() + " ");
        }

        //�R���e���c�e�[�u���A�f�ޓo�^�e�[�u���̓Ǎ�SQL
        else if (_SelSqlMode.equals(SelSqlMode.CmCd)) {

            sql.append(" SELECT ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            sql.append(" ," + Tbj17Content.CTRTKBN + " ");
            sql.append(" ," + Tbj17Content.CTRTNO + " ");
            sql.append(" ," + Tbj18SozaiKanriData.DATEFROM + " ");
            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
            /* 2015/12/04 JASRAC�Ή� HLC S.Fujimoto ADD Start */
            sql.append(" ,'" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + GetContentMaterialVO.TEMPFLG); //�{�f��
            /* 2015/12/04 JASRAC�Ή� HLC S.Fujimoto ADD End */

            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" ," + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");

            sql.append(" WHERE ");
            sql.append("     " + Tbj18SozaiKanriData.CMCD + " ");
            sql.append(" =  " + Tbj17Content.CMCD + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" =  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" =  " + Tbj17Content.CTRTNO + " ");
            sql.append(" AND " + Tbj17Content.CMCD + " ");
            sql.append(" IN ( ");
            sql.append(" SELECT ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = '" + _vo.getCTRTKBN() + "' ");
            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
            sql.append(" ) ");

            /* 2015/12/04 JASRAC�Ή� HLC S.Fujimoto ADD Start */
            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj16ContractInfo.NAMES + ",");
            sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
            sql.append(" " + Tbj16ContractInfo.DATETO + ",");
            sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");    //���f��

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " IN (");
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD);
            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME);
            sql.append(" WHERE");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = '" + _vo.getCTRTKBN() + "' AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = '" + _vo.getCTRTNO() + "'");
            sql.append(" )");

            sql.append(" ORDER BY ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            /* 2015/12/04 JASRAC�Ή� HLC S.Fujimoto ADD End */
        }

//        //�f�ޓo�^10��CM�R�[�h�ɕR�Â��_����擾SQL
//        else if (_SelSqlMode.equals(SelSqlMode.ContractInfo)) {
//
//            sql.append(" SELECT ");
//            sql.append("  " + Tbj16ContractInfo.DATEFROM + " ");
//            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
//            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//            sql.append(" FROM ");
//            sql.append("  " + Tbj17Content.TBNAME + " ");
//            sql.append(" ," + Tbj16ContractInfo.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("  " + Tbj17Content.CMCD + " ");
//            sql.append(" = '" + _cond3.getStrCmCd() + "' ");
//            sql.append(" AND " + Tbj16ContractInfo.DELFLG + " ");
//            sql.append(" != '" + DeleteYes + "' ");
//            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
//            sql.append(" = " + Tbj16ContractInfo.CTRTKBN + " ");
//            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
//            sql.append(" = " + Tbj16ContractInfo.CTRTNO + " ");
//            sql.append(" ORDER BY ");
//            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
//            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
//        }

        //�_��R�[�hMAX�l�擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.CTRTNO)) {

            sql.append(" SELECT ");
            sql.append(" MAX(" + Tbj16ContractInfo.CTRTNO + ") ");
            sql.append(" AS " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = '" + _vo.getCTRTKBN() + "' ");
            sql.append(" AND ");
            sql.append(" SUBSTR(" + Tbj16ContractInfo.CTRTNO + ",1,4) ");
            sql.append(" = " + "(TO_CHAR (SYSDATE, 'YYMM'))" + " ");
        }

        //�_����ύX���O�擾SQL
        else if (_SelSqlMode.equals(SelSqlMode.History)) {

            sql.append(" SELECT ");
            sql.append("     " + Mbj12Code.CODENAME + " AS HISTORYNM "); //��Ƌ敪
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             " + Mbj12Code.CODENAME);
            sql.append("         FROM ");
            sql.append("             " + Mbj12Code.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Mbj12Code.CODETYPE + " = '" + CODETYPE_CONTRACTINFO + "' ");
            sql.append("         AND ");
            sql.append("             " + Mbj12Code.KEYCODE + " = " + Tbj24LogContractInfo.CTRTKBN + " ");
            sql.append("     ) CTRTKBNNAM"); //�_����
            sql.append("    ,    '0' as ROWST "); //�s�X�e�[�^�X
            sql.append("    ,    '0' as COLST "); //��X�e�[�^�X
            sql.append("    ," + Tbj24LogContractInfo.CTRTNO + " "); //�_��R�[�h
            sql.append("    ," + Tbj24LogContractInfo.CTRTKBN + " "); //���_����
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             " + Mbj05Car.CARNM);
            sql.append("         FROM ");
            sql.append("             " + Mbj05Car.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Mbj05Car.DCARCD + "(+) = " + Tbj24LogContractInfo.DCARCD);
            sql.append("     ) SHASHU"); //�Ԏ�
            sql.append("    ," + Tbj24LogContractInfo.CATEGORY + " "); //�J�e�S��
            sql.append("    ," + Tbj24LogContractInfo.MUSIC + " "); //�Ȗ�
            sql.append("    ," + Tbj24LogContractInfo.NAMES + " "); //�l���A�A�[�e�B�X�g
            sql.append("    ," + Tbj24LogContractInfo.DATEFROM + " "); //����(From)
            sql.append("    ," + Tbj24LogContractInfo.DATETO + " "); //����(To)
            sql.append("    ," + Tbj24LogContractInfo.JASRACFLG + " "); //JASRAC�o�^
            sql.append("    ," + Tbj24LogContractInfo.SALEFLG + " "); //CD����
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
            sql.append("    ," + Tbj24LogContractInfo.ENDTITLEFLG + " "); //�Ԃ牺����
            sql.append("    ," + Tbj24LogContractInfo.ARRGORGFLG + " "); //�A�����W�E�I���W�i��
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */

            sql.append("    ," + Tbj24LogContractInfo.BIKO + " "); //���l
            sql.append("    ," + Tbj24LogContractInfo.CRTNM + " "); //�o�^��
            sql.append("    ," + Tbj24LogContractInfo.CRTAPL + " "); //�o�^�v���O����
            sql.append("    ," + Tbj24LogContractInfo.CRTID + " "); //�o�^��ID
            sql.append("    ," + Tbj24LogContractInfo.CRTDATE + " "); //�o�^����
            sql.append("    ," + Tbj24LogContractInfo.UPDNM + " "); //�X�V��
            sql.append("    ," + Tbj24LogContractInfo.UPDDATE + " "); //�X�V����

            sql.append(" FROM ");
            sql.append("     " + Tbj24LogContractInfo.TBNAME + " ");
            sql.append("    ," + Mbj12Code.TBNAME + " ");

            sql.append(" WHERE ");
            sql.append("     " + Tbj24LogContractInfo.HISTORYKEY + " = " + ConvertToDBString(_condLogContractInfo.getHistorykey()));
            sql.append(" AND " + Mbj12Code.CODETYPE + " = '33' ");
            sql.append(" AND " + Mbj12Code.KEYCODE + " = " + Tbj24LogContractInfo.HISTORYKBN + " ");
            sql.append(" ORDER BY ");
            sql.append("     " + Tbj24LogContractInfo.HISTORYNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.SearchM)) {

            //�{�f��
            sql.append(" SELECT ");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" " + Mbj05Car.CARNM + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + SozaiKanriDataVO.TEMPFLG);
            sql.append(" FROM ");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);
            sql.append(" WHERE ");
            sql.append(" " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD + " AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            /* 2015/11/30 JASRAC�Ή� HLC S.Fujimoto ADD Start */
            sql.append(" UNION ALL");

            //���f��
            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" " + Mbj05Car.CARNM + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Mbj05Car.DCARCD + " = " + Tbj36TempSozaiKanriData.DCARCD);
            /* 2015/11/30 JASRAC�Ή� HLC S.Fujimoto ADD End */

            sql.append(" ORDER BY ");
            sql.append(Tbj18SozaiKanriData.CRTDATE + ", ");
            sql.append(Tbj18SozaiKanriData.CMCD);

        } else if (_SelSqlMode.equals(SelSqlMode.Category)) {

            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.CATEGORY + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.CATEGORY + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY);

            sql.append(" FROM");
            sql.append(" (");

            //�{�f��
            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD  + " = " + Mbj05Car.DCARCD + "(+)");
            sql.append(" GROUP BY");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY);

            sql.append(" UNION ALL");

            //���f��
            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.TEMPCMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD);
            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD End */

        } else if (_SelSqlMode.equals(SelSqlMode.Second)) {

            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.NOKBN + " ");
//            sql.append("    ," + Tbj18SozaiKanriData.SECOND + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.NOKBN + " ");
//            sql.append("    ," + Tbj18SozaiKanriData.SECOND + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);

            sql.append(" FROM");
            sql.append(" (");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + " " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + " " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);

            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + " " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ")  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);
            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD End */

        } else if (_SelSqlMode.equals(SelSqlMode.Syatan)) {

            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.SYATAN + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.SYATAN + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN);

            sql.append(" FROM");
            sql.append(" (");

            sql.append(" SELECT");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN + "  " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" MIN( " + Tbj18SozaiKanriData.CRTDATE + ")  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN( " + Tbj18SozaiKanriData.CMCD + ")  " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append("  " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append("  " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append("  " + Tbj18SozaiKanriData.DCARCD + " = MBJ05_DCARCD(+) AND");
            sql.append("  " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            sql.append(" GROUP BY");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN);

            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + " " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append("  " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append("  " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = MBJ05_DCARCD(+) AND");
            sql.append("  " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append("  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append("  " + Tbj18SozaiKanriData.CMCD);
            /* 2015/11/27 JASRAC�Ή� HLC S.Fujimoto MOD End */
        }

        return sql.toString();
    }


    /**
     * �g�p�f�ޕ\���p(�^�����g�E�i���[�^�[)�f�[�^�̌������s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindUseMaterialVO> findUseMaterialTalentListByCondition() throws HAMException {
        super.setModel(new FindUseMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.TALENT;
            return (List<FindUseMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �g�p�f�ޕ\���p(�y��)�f�[�^�̌������s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindUseMaterialVO> findUseMaterialMusicListByCondition() throws HAMException {
        super.setModel(new FindUseMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.MUSIC;
            return (List<FindUseMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �R���e���c�f�[�^�̃J�E���g���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<ContractDeleteCVO> countContentListByCondition(ContractDeleteCondition cond) throws HAMException {
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new ContractDeleteCVO());
        try {
            _SelSqlMode = SelSqlMode.CountC;
            _cond2 = cond;
            return (List<ContractDeleteCVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * JASRAC�f�[�^�̃J�E���g���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<ContractDeleteJVO> countJasracListByCondition(ContractDeleteCondition cond) throws HAMException {
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new ContractDeleteJVO());
        try {
            _SelSqlMode = SelSqlMode.CountJ;
            _cond2 = cond;
            return (List<ContractDeleteJVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * TIMESTAMP���ڒl���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public Date findTimeStamp(GetContractInfoListCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.TimeStamp;
            _cond4 = cond;
            List<Tbj16ContractInfoVO> _tbj16ContractInfoVO = (List<Tbj16ContractInfoVO>) super.find();
            Date strUPDDATE = _tbj16ContractInfoVO.size() <= 0 ? null : _tbj16ContractInfoVO.get(0).getUPDDATE();
            return strUPDDATE;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �_��R�[�h��MAX�l�̌������s���܂�
     *
     * @return �_��R�[�h��MAX�l
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public String searchCtrtNoByCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.CTRTNO;
            _vo = vo;
            //List<AbstractModel> _tbj16ContractInfoVO = (List<AbstractModel>) super.find();
            List<Tbj16ContractInfoVO> _tbj16ContractInfoVO = (List<Tbj16ContractInfoVO>) super.find();
            String strCtrtNo = _tbj16ContractInfoVO.get(0).getCTRTNO();
            if (strCtrtNo.length() == 0) {
                Calendar calendar = Calendar.getInstance();
                Date nowTime = calendar.getTime();
                strCtrtNo = DateUtil.toStringGeneral(nowTime, "yyMM") + "001";
            } else {
                //���s�O�̔ԍ��i�o�^�ςݔԍ��j��999��ꍇ�A�G���[
                if (Integer.valueOf(strCtrtNo.substring(strCtrtNo.length() - 3)) >= 999)
                    throw new HAMException("�����̔Ԍ����ӂ�", "BJ-E0001");

                int intCtrtNo = Integer.parseInt(strCtrtNo) + 1;
                strCtrtNo = Integer.toString(intCtrtNo);

            }
            return strCtrtNo;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �R���e���c�e�[�u���A�f�ޓo�^�e�[�u���̓Ǎ����s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<GetContentMaterialVO> getContentMaterialCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new GetContentMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.CmCd;
            _vo = vo;
            return (List<GetContentMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

//    /**
//     * �f�ޓo�^��10��CM�R�[�h�ɕR�Â��_����̎擾���s���܂�
//     *
//     * @return �ėp�e�[�u���}�X�^VO���X�g
//     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
//     */
//    @SuppressWarnings("unchecked")
//    public List<ContractContentVO> getContractContentCondition(UpdateContractInfoCondition cond) throws HAMException {
//        if (cond == null) {
//            throw new HAMException("�����G���[", "BJ-E0001");
//        }
//        super.setModel(new ContractContentVO());
//        try {
//            _SelSqlMode = SelSqlMode.ContractInfo;
//            _cond3 = cond;
//            return (List<ContractContentVO>) super.find();
//        } catch (UserException e) {
//            throw new HAMException(e.getMessage(), "BJ-E0001");
//        }
//    }

    //    /**
    //     * �_����e�[�u���̌������s���܂�
    //     *
    //     * @return �ėp�e�[�u���}�X�^VO���X�g
    //     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
    //     */
    //    @SuppressWarnings("unchecked")
    //    public List<Tbj16ContractInfoVO> findContractByCondition(GetContractInfoListCondition cond) throws HAMException {
    //        if (cond == null) {
    //            throw new HAMException("�����G���[", "BJ-E0001");
    //        }
    //        super.setModel(new Tbj16ContractInfoVO());
    //        try {
    //            if (cond.getStrCtrtKbn().equals(CTRTKBN_MUSIC)) {
    //                _SelSqlMode = SelSqlMode.ContractMusic;
    //            }
    //            else
    //            {
    //                _SelSqlMode = SelSqlMode.ContractTalent;
    //            }
    //            _cond4 = cond;
    //            return (List<Tbj16ContractInfoVO>) super.find();
    //        } catch (UserException e) {
    //            throw new HAMException(e.getMessage(), "BJ-E0001");
    //        }
    //    }

    /**
     * ������ʂɕ\������^�����g�E�i���[�^�[�E���̑��f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindLogContractInfoVO> findLogContractInfo(FindLogContractInfoCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindLogContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.History;
            _condLogContractInfo = cond;
            return (List<FindLogContractInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �f�ތ�����ʂɕ\������f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SozaiKanriDataVO> findSozaiKanriData(MaterialSearchCondition cond) throws HAMException {
        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.SearchM;
            return (List<SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �J�e�S���̃��X�g�ɕ\������f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getCategory() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Category;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �b���̃��X�g�ɕ\������f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getSecond() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Second;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �Ԏ�S���̃��X�g�ɕ\������f�[�^���擾���܂�
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getSyatan() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Syatan;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList List ��������
     * @return List<CommonCodeMasterVO> �ϊ���̌�������
     */
    @Override
    @SuppressWarnings("unchecked")
    protected List createFindedModelInstances(List hashList) {
        List list = null;
        if (getModel() instanceof ContractDeleteCVO) {
            list = new ArrayList<ContractDeleteCVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                ContractDeleteCVO vo = new ContractDeleteCVO();
                vo.setCOUNT(((BigDecimal)result.get("COUNT")).intValue());

                //�������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (getModel() instanceof ContractDeleteJVO) {
            list = new ArrayList<ContractDeleteJVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                ContractDeleteJVO vo = new ContractDeleteJVO();
                vo.setCOUNT(((BigDecimal)result.get("COUNT")).intValue());

                //�������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else {
            list = super.createFindedModelInstances(hashList);
        }
        return list;
    }

    /**
     * EXEC-SQL����
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        //�_����e�[�u���̘_���폜SQL
        if (_ExecSqlMode.equals(ExecSqlMode.DeleteC)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj16ContractInfo.DELFLG + " ");
            sql.append(" = '" + DeleteYes + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
            sql.append(" = '" + _vo.getUPDNM() + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDAPL + " ");
            sql.append(" = '" + _vo.getUPDAPL() + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
            sql.append(" = '" + _vo.getUPDID() + "' ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + _vo.getCTRTKBN() + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
        }

        //JASRAC�e�[�u���̘_���폜SQL
        else if (_ExecSqlMode.equals(ExecSqlMode.DeleteJ)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj19Jasrac.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj19Jasrac.DELFLG + " ");
            sql.append(" = '" + DeleteYes + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj19Jasrac.UPDNM + " ");
            sql.append(" = '" + _vo.getUPDNM() + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDAPL + " ");
            sql.append(" = '" + _vo.getUPDAPL() + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDID + " ");
            sql.append(" = '" + _vo.getUPDID() + "' ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj19Jasrac.CTRTKBN + " ");
            sql.append(" = " + _vo.getCTRTKBN() + " ");
            sql.append(" AND " + Tbj19Jasrac.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
        }

        //�_����e�[�u����UpdateSQL(�_��R�[�h�ɕύX���Ȃ��ꍇ)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateC)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" SET ");
            sql.append(" " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBN()) + " ");
            sql.append(" ," + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNONEW()) + " ");
            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
            sql.append(" = " + ConvertToDBString(_vo.getNAMES()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDATEFROM()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDATETO()) + " ");
            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
            sql.append(" = " + ConvertToDBString(_vo.getMUSIC()) + " ");
            sql.append(" ," + Tbj16ContractInfo.SALEFLG + " ");
            sql.append(" = " + ConvertToDBString(_vo.getSALEFLG()) + " ");
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
            if(_vo.getENDTITLEFLG() != null){
                sql.append(" ," + Tbj16ContractInfo.ENDTITLEFLG+ " ");
                sql.append(" = " + ConvertToDBString(_vo.getENDTITLEFLG()) + " ");
            }
            if(_vo.getARRGORGFLG() != null){
                sql.append(" ," + Tbj16ContractInfo.ARRGORGFLG+ " ");
                sql.append(" = " + ConvertToDBString(_vo.getARRGORGFLG()) + " ");
            }
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
            sql.append(" ," + Tbj16ContractInfo.BIKO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getBIKO()) + " ");
            sql.append(" ," + Tbj16ContractInfo.HISTORYKEY + " ");
            sql.append(" = " + ConvertToDBString(_vo.getHISTORYKEY()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDNM()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDAPL + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDAPL()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDID()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DCARCD + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDCARCD()) + " ");
            sql.append(" ," + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCATEGORY()) + " ");
            sql.append(" ," + Tbj16ContractInfo.JASRACFLG + " ");
            sql.append(" = " + ConvertToDBString(_vo.getJASRACFLG()) + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBNOLD()) + " "); //�_����(��)
            sql.append(" AND ");
            sql.append("  " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNO()) + " ");
        }

        //�R���e���c�e�[�u����UpdateSQL(�_��R�[�h�ɕύX������ꍇ)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateContent)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" SET ");
            sql.append(" " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBN()) + " ");
            sql.append(" ," + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNONEW()) + " "); //�_��R�[�h(�����̔Ԃ��ꂽ����)
            sql.append(" ," + Tbj17Content.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj17Content.UPDNM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDNM()) + " ");
            sql.append(" ," + Tbj17Content.UPDAPL + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDAPL()) + " ");
            sql.append(" ," + Tbj17Content.UPDID + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDID()) + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBNOLD()) + " "); //�_����(��)
            sql.append(" AND ");
            sql.append("  " + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNO()) + " ");
        }

        //�f�ޓo�^�e�[�u����UpdateSQL(�_����ԍX�V��)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateKLIMIT)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj18SozaiKanriData.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj18SozaiKanriData.KLIMIT + " = " + ConvertToDBString(_vo2.getKLIMIT()) + " "); //�����g�p����
            sql.append(" ," + Tbj18SozaiKanriData.UPDDATE + " = " + "SYSDATE" + " "); //�f�[�^�X�V����
            sql.append(" ," + Tbj18SozaiKanriData.UPDNM + " = " + ConvertToDBString(_vo2.getUPDNM()) + " "); //�f�[�^�X�V��
            sql.append(" ," + Tbj18SozaiKanriData.UPDAPL + " = " + ConvertToDBString(_vo2.getUPDAPL()) + " "); //�X�V�v���O����
            sql.append(" ," + Tbj18SozaiKanriData.UPDID + " = " + ConvertToDBString(_vo2.getUPDID()) + " "); //�X�V�S����ID
            sql.append(" WHERE ");
            sql.append("  " + Tbj18SozaiKanriData.CMCD + " = " + " ");
            sql.append("    ( ");
            sql.append("    SELECT ");
            sql.append("     " + Tbj17Content.CMCD + " ");
            sql.append("    FROM ");
            sql.append("     " + Tbj17Content.TBNAME + " ");
            sql.append("    WHERE ");
            sql.append("     " + Tbj17Content.CTRTKBN + " = " + ConvertToDBString(_vo2.getCTRTKBN()) + " ");
            sql.append("    AND ");
            sql.append("     " + Tbj17Content.CTRTNO + " = " + ConvertToDBString(_vo2.getCTRTNO()) + " ");
            sql.append("    ) ");
        }

        //�_����e�[�u����InsertSQL
        else if (_ExecSqlMode.equals(ExecSqlMode.InsertHistory)) {

            Tbj24LogContractInfoVO vo = (Tbj24LogContractInfoVO) getModel();

            sql.append(" INSERT INTO ");
            sql.append("    " + Tbj24LogContractInfo.TBNAME + " ");
            sql.append(" ( ");
            sql.append("     " + Tbj24LogContractInfo.CTRTKBN);
            sql.append("    ," + Tbj24LogContractInfo.CTRTNO);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYKEY);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYNO);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYKBN);
            sql.append("    ," + Tbj24LogContractInfo.DCARCD);
            sql.append("    ," + Tbj24LogContractInfo.CATEGORY);
            sql.append("    ," + Tbj24LogContractInfo.DELFLG);
            sql.append("    ," + Tbj24LogContractInfo.NAMES);
            sql.append("    ," + Tbj24LogContractInfo.DATEFROM);
            sql.append("    ," + Tbj24LogContractInfo.DATETO);
            sql.append("    ," + Tbj24LogContractInfo.MUSIC);
            sql.append("    ," + Tbj24LogContractInfo.JASRACFLG);
            sql.append("    ," + Tbj24LogContractInfo.SALEFLG);
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
            sql.append("    ," + Tbj24LogContractInfo.ENDTITLEFLG);
            sql.append("    ," + Tbj24LogContractInfo.ARRGORGFLG);
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
            sql.append("    ," + Tbj24LogContractInfo.BIKO);
            sql.append("    ," + Tbj24LogContractInfo.CRTDATE);
            sql.append("    ," + Tbj24LogContractInfo.CRTNM);
            sql.append("    ," + Tbj24LogContractInfo.CRTAPL);
            sql.append("    ," + Tbj24LogContractInfo.CRTID);
            sql.append("    ," + Tbj24LogContractInfo.UPDDATE);
            sql.append("    ," + Tbj24LogContractInfo.UPDNM);
            sql.append("    ," + Tbj24LogContractInfo.UPDAPL);
            sql.append("    ," + Tbj24LogContractInfo.UPDID);
            sql.append(" ) ");
            sql.append(" SELECT ");
            sql.append("     " + Tbj16ContractInfo.CTRTKBN);
            sql.append("    ," + Tbj16ContractInfo.CTRTNO);
            sql.append("    ," + Tbj16ContractInfo.HISTORYKEY);
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             NVL(MAX(" + Tbj24LogContractInfo.HISTORYNO + "), 0) + 1");
            sql.append("         FROM ");
            sql.append("             " + Tbj24LogContractInfo.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Tbj24LogContractInfo.HISTORYKEY + " = " + Tbj16ContractInfo.HISTORYKEY);
            sql.append("     )");
            sql.append("    ," + ConvertToDBString(vo.getHISTORYKBN()) + "");
            sql.append("    ," + Tbj16ContractInfo.DCARCD);
            sql.append("    ," + Tbj16ContractInfo.CATEGORY);
            sql.append("    ," + Tbj16ContractInfo.DELFLG);
            sql.append("    ," + Tbj16ContractInfo.NAMES);
            sql.append("    ," + Tbj16ContractInfo.DATEFROM);
            sql.append("    ," + Tbj16ContractInfo.DATETO);
            sql.append("    ," + Tbj16ContractInfo.MUSIC);
            sql.append("    ," + Tbj16ContractInfo.JASRACFLG);
            sql.append("    ," + Tbj16ContractInfo.SALEFLG);
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
            sql.append("    ," + Tbj16ContractInfo.ENDTITLEFLG);
            sql.append("    ," + Tbj16ContractInfo.ARRGORGFLG);
            /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
            sql.append("    ," + Tbj16ContractInfo.BIKO);
            sql.append("    ," + Tbj16ContractInfo.CRTDATE);
            sql.append("    ," + Tbj16ContractInfo.CRTNM);
            sql.append("    ," + Tbj16ContractInfo.CRTAPL);
            sql.append("    ," + Tbj16ContractInfo.CRTID);
            sql.append("    ," + Tbj16ContractInfo.UPDDATE);
            sql.append("    ," + Tbj16ContractInfo.UPDNM);
            sql.append("    ," + Tbj16ContractInfo.UPDAPL);
            sql.append("    ," + Tbj16ContractInfo.UPDID);

            sql.append(" FROM ");
            sql.append("     " + Tbj16ContractInfo.TBNAME);
            sql.append(" WHERE ");
            sql.append("     " + Tbj16ContractInfo.CTRTKBN + " = " + ConvertToDBString(vo.getCTRTKBN()));
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " = " + ConvertToDBString(vo.getCTRTNO()));
        }

        return sql.toString();
    }

    /**
     * �_����e�[�u���̘_���폜���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void deleteContractInfoCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        try {
            _ExecSqlMode = ExecSqlMode.DeleteC;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * JASRAC�e�[�u���̘_���폜���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void deleteJasracCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        try {
            _ExecSqlMode = ExecSqlMode.DeleteJ;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * �_����e�[�u����Update(�_���ޕύX�Ȃ�)���s���܂�UpdateCtrtC
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void updateContractInfoCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateC;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * �R���e���c�e�[�u��(�_���ޕύX��)��Update���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void updateContentCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateContent;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * �����g�p����(�_����o�^��)��Update���s���܂�
     *
     * @return �ėp�e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void updateKenriLimit(Tbj18SozaiKanriDataUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateKLIMIT;
            _vo2 = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * �_����ύX���O�i�����j��Insert���s���܂�
     *
     * @return �e�[�u���}�X�^VO���X�g
     * @throws UserException �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    public void insertHistoryForContractInfo(Tbj24LogContractInfoVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _ExecSqlMode = ExecSqlMode.InsertHistory;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    private String ConvertToDBString(Object obj) {
        if (obj == null) {
            return null;
        }
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

}
